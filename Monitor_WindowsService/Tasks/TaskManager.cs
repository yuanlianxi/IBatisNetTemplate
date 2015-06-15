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

        private void GenerateTasks()
        {
            int count = ServiceContext.TaskInfoService.SelectTotalCount();
            IList<TaskInfo> taskInfos = ServiceContext.TaskInfoService.SelectValidTasks();
            Logger.LogTaskAcquisition(DateTime.Now, count, taskInfos.Count,DateTime.Now);
            foreach (var taskInfo in taskInfos)
            {
                listTask.Add(TaskFactory.CreateTask(taskInfo));
            }
        }
        public void Execute()
        {
            GenerateTasks();
            ExecuteTasks();
        }

        private void ExecuteTasks()
        {

            foreach (var task in listTask)
            {
                ExecuteTask(task);
            }
        }
        private void ExecuteTask(TaskBase task)
        {
            task.StartDateTime = DateTime.Now;
            task.Execute();
            CheckTask(task);
        }
        private void CheckTask(TaskBase task)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = now - task.StartDateTime;
            switch (task.State())
            {
                case TaskBase.TaskState.Executing:
                    Logger.LogTaskExecutionCheck(task, TaskBase.TaskState.Executing, now);
                    if (ts.TotalMilliseconds >= task.OverTimeMilliSeconds)
                    {
                        task.EndDateTime = now;
                        Logger.LogTaskExecutionResult(task, (int)TaskBase.TaskState.Executing, new Exception("超时"), true, now);
                        Logger.LogTaskWarning(task, "超时", now);
                        SendWarning(task);
                        task.Abort();
                    }
                    else
                    {
                        Thread.Sleep(task.OverTimeMilliSeconds / 10);
                        CheckTask(task);
                    }
                    break;
                case TaskBase.TaskState.End:
                    Logger.LogTaskExecutionCheck(task, TaskBase.TaskState.End, now);
                    if (ts.TotalMilliseconds > task.OverTimeMilliSeconds)
                    {
                        Logger.LogTaskExecutionResult(task, (int)TaskBase.TaskState.End, new Exception("超时"), true, now);
                        Logger.LogTaskWarning(task, "超时", now);
                        SendWarning(task);
                    }
                    else
                    {
                        if (task.MinValue < task.ReturnValue && task.ReturnValue < task.MaxValue)
                        {
                            Logger.LogTaskExecutionResult(task, (int)TaskBase.TaskState.End, null, false, now);
                        }
                        else
                        {
                            Logger.LogTaskExecutionResult(task, (int)TaskBase.TaskState.End, new Exception("超出阈值"), true, now);
                            SendWarning(task);
                        }
                    }
                    break;
                case TaskBase.TaskState.Exception:
                    task.EndDateTime = now;
                    Logger.LogTaskExecutionCheck(task, TaskBase.TaskState.Exception, now);
                    Logger.LogTaskExecutionResult(task, (int)TaskBase.TaskState.Exception, task.Error, true, now);
                    if (task.TryTimes >= 3)
                    {
                        Logger.LogTaskWarning(task, "超过尝试次数！", now);
                        SendWarning(task);
                    }
                    else
                    {
                        task.TryTimes++;
                        ExecuteTask(task);
                    }
                    break;
            }

        }
        public void SendWarning(TaskBase task) { }


    }
}
