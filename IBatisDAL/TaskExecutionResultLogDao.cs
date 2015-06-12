using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using ApplicationCommon;

namespace IBatisDAL
{
    public class TaskExecutionResultLogDao : DaoBase, ITaskExecutionResultLogDao
    {

        public int Insert(TaskExecutionResultLog log)
        {
            int obj = ExecuteQueryForObject<int>("TaskExecutionResultLog-Insert", log);
            return obj;
        }
    }
}
