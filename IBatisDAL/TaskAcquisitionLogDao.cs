using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisDAL;
using IBatisIDAL;
using ApplicationCommon;

namespace IBatisDAL
{
    public class TaskAcquisitionLogDao:BaseDao, ITaskAcquisitionLogDao
    {

        public int Insert(TaskAcquisitionLog log)
        {
            int obj = ExecuteQueryForObject<int>("TaskAcquisitionLog-Insert", log);
            return obj;
        }
    }
}
