using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;

namespace IBatisIBLL
{
    public interface ITaskValueLimitsService
    {
        int Insert(TaskValueLimits taskValueLimits);
        IList<TaskValueLimits> SelectByTaskId(int taskId);
    }
}
