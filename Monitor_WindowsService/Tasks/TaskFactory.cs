using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisBLL;

namespace Monitor_WindowsService.Tasks
{
    class TaskFactory
    {
        public static TaskBase CreateTask(TaskInfo taskInfo)
        {
            switch (taskInfo.Method)
            {
                case 1:
                    return CreateSqlTask(taskInfo);
                case 2: return CreateWebServiceTask(taskInfo);
                case 3: return CreateHttpLinkTask(taskInfo);
            }
            return null;
        }

        private static SqlTask CreateSqlTask(TaskInfo taskInfo)
        {
            SqlTask sqlTask = new SqlTask(taskInfo.Content, taskInfo.Extend);
            InitTask(sqlTask, taskInfo);
            return sqlTask;
        }

        private static WebServiceTask CreateWebServiceTask(TaskInfo taskInfo)
        {
            WebServiceTask task = new WebServiceTask(taskInfo.Content, taskInfo.Extend, null);
            InitTask(task, taskInfo);
            return task;
        }

        private static HttpLinkTask CreateHttpLinkTask(TaskInfo taskInfo)
        {
            HttpLinkTask task = new HttpLinkTask(taskInfo.Content);
            InitTask(task, taskInfo);
            return task;
        }

        private static void InitTask(TaskBase task, TaskInfo taskInfo)
        {
            IList<TaskValueLimits> valueLimits = ServiceContext.TaskValueLimitsService.SelectByTaskId(taskInfo.Id);
            TaskValueLimits taskValueLimits = valueLimits[0];
            task.TaskId = taskInfo.Id;
            task.OverTimeMilliSeconds = taskInfo.OverTimeSeconds * 1000;
            task.MaxValue = taskValueLimits.MaxValue;
            task.MinValue = taskValueLimits.MinValue;
        }
    }
}
