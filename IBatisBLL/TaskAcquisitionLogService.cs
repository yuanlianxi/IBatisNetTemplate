using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using IBatisIBLL;

namespace IBatisBLL
{
    public class TaskAcquisitionLogService : ServiceBase<ITaskAcquisitionLogDao>, ITaskAcquisitionLogService 
    {
        private TaskAcquisitionLogService() : base(DALContextEnum.DefaultDAL) { }
        private static readonly TaskAcquisitionLogService _instance = new TaskAcquisitionLogService();
        public static TaskAcquisitionLogService Instance { get { return _instance; } }
        public int Insert(TaskAcquisitionLog log)
        {
            return Dao.Insert(log);
        }
    }
}
