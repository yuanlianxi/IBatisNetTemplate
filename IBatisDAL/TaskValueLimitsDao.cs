using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;

namespace IBatisDAL
{
    public class TaskValueLimitsDao : BaseDao, ITaskValueLimitsDao
    {
        public int Insert(TaskValueLimits taskValueLimits)
        {
            throw new NotImplementedException();
        }

        public IList<TaskValueLimits> SelectByTaskId(int taskId)
        {
            IList<TaskValueLimits> ilistResult = ExecuteQueryForList<TaskValueLimits>("", taskId);
            return ilistResult;
        }
    }
}
