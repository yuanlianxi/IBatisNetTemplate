using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using ApplicationCommon;

namespace IBatisDAL
{
    public class TaskExecutionCheckLogDao : DaoBase, ITaskExecutionCheckLogDao
    {

        public int Insert(TaskExecutionCheckLog log)
        {
            int obj = ExecuteQueryForObject<int>("TaskExecutionCheckLog-Insert", log);
            return obj;
        }
    }
}
