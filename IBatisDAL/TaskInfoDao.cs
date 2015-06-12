using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using ApplicationCommon;

namespace IBatisDAL
{
    public class TaskInfoDao : BaseDao, ITaskInfoDao
    {
        public int Insert(TaskInfo taskInfo)
        {
            int obj = ExecuteQueryForObject<int>("TaskInfo-Insert", taskInfo);
            return obj;
        }

        public int SelectTotalCount()
        {
            int obj = ExecuteQueryForObject<int>("TaskInfo-SelectTotalCount", null);
            return obj;
        }

        public IList<TaskInfo> SelectValidTasks()
        {
            IList<TaskInfo> ilistResult = ExecuteQueryForList<TaskInfo>("TaskInfo-Select", null);
            return ilistResult;
        }
    }
}
