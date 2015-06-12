using IBatisIBLL;
using IBatisIDAL;
using IBatisEntity;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisEntity;
using IBatisIDAL;

namespace IBatisBLL
{
    public class TaskValueLimitsService : BaseService<ITaskValueLimitsDao>,ITaskValueLimitsService 
    {
        private TaskValueLimitsService() : base(DALContextEnum.DefaultDAL) { }
        private static readonly TaskValueLimitsService _instance = new TaskValueLimitsService();
        public static TaskValueLimitsService Instance { get { return _instance; } }
        public int Insert(TaskValueLimits taskValueLimits)
        {
            throw new NotImplementedException();
        }

        public IList<TaskValueLimits> SelectByTaskId(int taskId)
        {
            IList<TaskValueLimits> ilistResult = Dao.SelectByTaskId(taskId);
            return ilistResult;
        }
    }
}
