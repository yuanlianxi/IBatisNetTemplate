using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIBLL
{
    public interface ITaskInfoService
    {
        int Insert(TaskInfo taskInfo);
        int SelectTotalCount();
        IList<TaskInfo> SelectValidTasks();
    }
}
