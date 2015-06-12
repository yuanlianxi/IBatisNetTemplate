using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;
using IBatisIBLL;

namespace IBatisBLL
{
    public class TaskInfoService : ServiceBase<ITaskInfoDao>, ITaskInfoService
    {

        private TaskInfoService() : base(DALContextEnum.DefaultDAL) { }
        private static readonly TaskInfoService _instance = new TaskInfoService();
        public static TaskInfoService Instance { get { return _instance; } }
        public int Insert(TaskInfo taskInfo)
        {
            return Dao.Insert(taskInfo);
        }

        public int SelectTotalCount()
        {
            return Dao.SelectTotalCount();
        }

        public IList<TaskInfo> SelectValidTasks()
        {
            return Dao.SelectValidTasks();
        }
    }
}
