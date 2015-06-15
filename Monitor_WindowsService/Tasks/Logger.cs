using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisBLL;

namespace Monitor_WindowsService.Tasks
{
    public class Logger
    {
        public  static void LogTaskExecutionCheck(TaskBase task, TaskBase.TaskState taskState,DateTime createDateTime)
        {
            TaskExecutionCheckLog logInfo = new TaskExecutionCheckLog();
            logInfo.TaskId = task.TaskId;
            logInfo.TaskState = (int)taskState;
            logInfo.CreateDateTime = createDateTime;
            ServiceContext.TaskExecutionCheckLogService.Insert(logInfo);
        }

        public static void LogTaskAcquisition(DateTime dt, int totalCount, int validCout,DateTime createDateTime)
        {
            TaskAcquisitionLog logInfo = new TaskAcquisitionLog();
            logInfo.AcquisitionDateTime = dt;
            logInfo.TaskTotalCount = totalCount;
            logInfo.TaskValidCount = validCout;
            logInfo.CreateDateTime = createDateTime;
            ServiceContext.TaskAcquisitionLogService.Insert(logInfo);
        }
        public static void LogTaskExecutionResult(TaskBase task,int taskState, Exception exception, bool isWarn, DateTime createDateTime)
        {
            TaskExecutionResultLog logInfo = new TaskExecutionResultLog();
            logInfo.CreateDateTime = createDateTime;
            logInfo.TaskId = task.TaskId;
            logInfo.TaskDuringMilliSeconds = Convert.ToInt32((task.EndDateTime - task.StartDateTime).TotalMilliseconds);
            logInfo.TaskMaxDuringMilliSeconds = task.OverTimeMilliSeconds;
            logInfo.TaskReturnValueLimitMax = task.MaxValue;
            logInfo.TaskReturnValueLimitMin = task.MinValue;
            logInfo.TaskReturnValue = task.ReturnValue;
            logInfo.TaskExecuteStartTime = task.StartDateTime;
            logInfo.TaskState = taskState;
            logInfo.TaskExecuteEndTime = task.EndDateTime;

            bool isExcept = false;
            if (exception != null)
            {
                isExcept = true;
                logInfo.ExceptionInfo = exception.StackTrace ?? exception.Message ;
                logInfo.ExceptionType = exception.GetType().FullName;
            }

            logInfo.IsExcept = isExcept;
            logInfo.IsWarn = isWarn;
            ServiceContext.TaskExecutionResultLogService.Insert(logInfo);
        }
        public static void LogTaskWarning(TaskBase task, string warning,DateTime createDateTime)
        {
            TaskWarningLog log = new TaskWarningLog();
            log.TaskId = task.TaskId;
            log.CreateDateTime = createDateTime;
            log.WarnInfo = warning;
            ServiceContext.TaskWarningLogService.Insert(log);
        }
    }
}
