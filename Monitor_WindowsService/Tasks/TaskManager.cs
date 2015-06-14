using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisBLL;
using IBatisEntity;
using System.Threading;

namespace Monitor_WindowsService.Tasks
{
    class TaskManager
    {
        private IList<TaskBase> listTask = new List<TaskBase>();

        private void GenerateTask()
        {
            int count = ServiceContext.TaskInfoService.SelectTotalCount();
            IList<TaskInfo> taskInfos = ServiceContext.TaskInfoService.SelectValidTasks();
            LogTaskAcquisition(DateTime.Now, count, taskInfos.Count);
            foreach (var taskInfo in taskInfos)
            {
                listTask.Add(TaskFactory.CreateTask(taskInfo));
            }
        }

        public void ExecuteTasks()
        {
            foreach (var task in listTask)
            {
                ExecuteTask(task);
            }
        }
        public void ExecuteTask(TaskBase task){
            task.Execute();
            task.StartDateTime = DateTime.Now;
            CheckTask(task);
        }
        public void CheckTask(TaskBase task)
        {
            TimeSpan ts = DateTime.Now - task.StartDateTime;
            switch (task.State())
            {
                case TaskBase.TaskState.Executing:
                    if (ts.TotalMilliseconds >= task.OverTimeMilliSeconds)
                    {
                        task.Abort();
                    }
                    else
                    {
                        Thread.Sleep(task.OverTimeMilliSeconds / 10);
                        LogTaskExecutionCheck(task, TaskBase.TaskState.Executing);
                        CheckTask(task);
                    }
                    break;
                case TaskBase.TaskState.End:
                    if (ts.TotalMilliseconds > task.OverTimeMilliSeconds)
                    {
                        LogTaskExecutionCheck(task, TaskBase.TaskState.End);
                        LogTaskExecutionResult(task, new Exception("超时"), true);
                        LogTaskWarning(task, "超时");
                    }
                    else
                    {
                        LogTaskExecutionCheck(task, TaskBase.TaskState.End);
                        LogTaskExecutionResult(task, null, false);
                        
                    }
                    break;
                case TaskBase.TaskState.Exception:
                    if (task.TryTimes >= 3)
                    {
                        LogTaskExecutionCheck(task, TaskBase.TaskState.Exception);
                        LogTaskExecutionResult(task, task.Error, true);
                        LogTaskWarning(task, "超过尝试次数！");
                    }
                    else
                    {
                        LogTaskExecutionCheck(task, TaskBase.TaskState.Exception);
                        LogTaskExecutionResult(task, task.Error, true);
                        task.TryTimes++;
                        ExecuteTask(task);
                    }
                    break;
            }

        }
        public void SendWarning(TaskBase task) { }
        private void LogTaskExecutionCheck(TaskBase task, TaskBase.TaskState taskState)
        {
            TaskExecutionCheckLog logInfo = new TaskExecutionCheckLog();
            logInfo.TaskId = task.TaskId;
            logInfo.TaskState = (int)taskState;
            logInfo.CreateDateTime = DateTime.Now;
            ServiceContext.TaskExecutionCheckLogService.Insert(logInfo);
        }

        private void LogTaskAcquisition(DateTime dt,int totalCount, int validCout)
        {
            TaskAcquisitionLog logInfo = new TaskAcquisitionLog();
            logInfo.AcquisitionDateTime = dt;
            logInfo.TaskTotalCount = totalCount;
            logInfo.TaskValidCount = validCout;
            ServiceContext.TaskAcquisitionLogService.Insert(logInfo);
        }
        private void LogTaskExecutionResult(TaskBase task,Exception exception,bool isWarn) {
            TaskExecutionResultLog logInfo = new TaskExecutionResultLog();
            logInfo.CreateDateTime = DateTime.Now;
            logInfo.TaskId = task.TaskId;
            logInfo.TaskDuringMilliSeconds = Convert.ToInt32((task.EndDateTime - task.StartDateTime).TotalMilliseconds);
            logInfo.TaskMaxDuringMilliSeconds = task.OverTimeMilliSeconds;
            logInfo.TaskReturnValueLimitMax = task.MaxValue;
            logInfo.TaskReturnValueLimitMin = task.MinValue;
            logInfo.TaskReturnValue = task.ReturnValue;
            logInfo.TaskExecuteStartTime = task.StartDateTime;
            
            logInfo.TaskExecuteEndTime = task.EndDateTime;

            bool isExcept = false;
            if (exception != null)
            {
                isExcept = true;
            }

            logInfo.IsExcept = isExcept;
            logInfo.ExceptionInfo = exception.StackTrace;
            logInfo.ExceptionType = exception.GetType().FullName;
            logInfo.IsWarn = isWarn;
            
        }
        private void LogTaskWarning(TaskBase task,string warning) {
            TaskWarningLog log = new TaskWarningLog();
            log.TaskId = task.TaskId;
            log.CreateDateTime = DateTime.Now;
            log.WarnInfo = warning;
        }

    }
}
