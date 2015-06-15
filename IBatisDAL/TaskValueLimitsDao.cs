﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;

namespace IBatisDAL
{
    public class TaskValueLimitsDao : DaoBase, ITaskValueLimitsDao
    {
        public int Insert(TaskValueLimits taskValueLimits)
        {
            throw new NotImplementedException();
        }

        public IList<TaskValueLimits> SelectByTaskId(int taskId)
        {
            IList<TaskValueLimits> ilistResult = ExecuteQueryForList<TaskValueLimits>("TaskValueLimits-Select", taskId);
            return ilistResult;
        }
    }
}
