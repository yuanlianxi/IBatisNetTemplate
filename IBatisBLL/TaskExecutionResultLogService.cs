using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using IBatisIBLL;

namespace IBatisBLL
{
    public class TaskExecutionResultLogService : BaseService<ITaskExecutionResultLogDao>, ITaskExecutionResultLogService
    {
        private TaskExecutionResultLogService() : base(DALContextEnum.DefaultDAL) { }
        private static readonly TaskExecutionResultLogService _instance = new TaskExecutionResultLogService();
        public static TaskExecutionResultLogService Instance { get { return _instance; } }
        public int Insert(TaskExecutionResultLog log)
        {
            return Dao.Insert(log);
        }
    }
}
