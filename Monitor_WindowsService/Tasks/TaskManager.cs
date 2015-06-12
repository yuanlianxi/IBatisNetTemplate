using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisBLL;
using IBatisEntity;

namespace Monitor_WindowsService.Tasks
{
    class TaskManager
    {
        private IList<TaskBase> listTask;

        private void GenerateTask()
        {
            int count = ServiceContext.TaskInfoService.SelectTotalCount();
            IList<TaskInfo> taskInfos = ServiceContext.TaskInfoService.SelectValidTasks();
            foreach (var taskInfo in taskInfos)
            {

            }
        }

        private SqlTask CreateSqlTask(TaskInfo taskInfo)
        {
            SqlTask sqlTask = new SqlTask(taskInfo.Content,taskInfo.Extend,taskInfo.OverTimeSeconds * 1000);
            IList<TaskValueLimits> valueLimits = ServiceContext.TaskValueLimitsService.SelectByTaskId(taskInfo.Id);
            //sqlTask.MaxValue = valueLimits[0].
                return sqlTask;

        }
    }
}
