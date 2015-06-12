using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIDAL
{
    public interface ITaskInfoDao
    {
        int Insert(TaskInfo taskInfo);
        int SelectTotalCount();
        IList<TaskInfo> SelectValidTasks();
    }
}
