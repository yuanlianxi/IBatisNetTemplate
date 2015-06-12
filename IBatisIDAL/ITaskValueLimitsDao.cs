using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIDAL
{
    public interface ITaskValueLimitsDao
    {
        int Insert(TaskValueLimits taskValueLimits);
        IList<TaskValueLimits> SelectByTaskId(int taskId);
    }
}
