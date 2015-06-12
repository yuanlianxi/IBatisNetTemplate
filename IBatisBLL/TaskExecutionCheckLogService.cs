using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using IBatisIBLL;

namespace IBatisBLL
{
    public class TaskExecutionCheckLogService : ServiceBase<ITaskExecutionCheckLogDao>, ITaskExecutionCheckLogService
    {
        private TaskExecutionCheckLogService() : base(DALContextEnum.DefaultDAL) { }
        private static readonly TaskExecutionCheckLogService _instance = new TaskExecutionCheckLogService();
        public static TaskExecutionCheckLogService Instance { get { return _instance; } }
        public int Insert(TaskExecutionCheckLog log)
        {
            return Dao.Insert(log);
        }
    }
}
