using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using IBatisIBLL;

namespace IBatisBLL
{
    public class TaskWarningLogService : ServiceBase<ITaskWarningLogDao>,ITaskWarningLogService
    {
        private  TaskWarningLogService():base(DALContextEnum.DefaultDAL){}
        private static readonly TaskWarningLogService _instance = new TaskWarningLogService();
        public static TaskWarningLogService Instance { get { return _instance; } }
        public int Insert(TaskWarningLog log)
        {
            return Dao.Insert(log);
        }
    }
}
