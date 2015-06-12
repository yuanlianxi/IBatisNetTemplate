using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;

namespace IBatisDAL
{
    public class TaskWarningLogDao : DaoBase, ITaskWarningLogDao
    {
        public int Insert(TaskWarningLog log)
        {
            int result = ExecuteQueryForObject<int>("TaskWarningLog-Insert", log);
            return result;
        }
    }
}
