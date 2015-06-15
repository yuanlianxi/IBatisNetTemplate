using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskValueLimits
    {
        #region private fields

        private int id;
        private int? taskId;

        private int? maxValue;

        private int? minValue;

        private DateTime? createDateTime;

        private DateTime? lastUpdateDateTime;


        private bool? isActive;
        #endregion

        #region public Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        public int? MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        public int? MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        public DateTime? CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }
        public DateTime? LastUpdateDateTime
        {
            get { return lastUpdateDateTime; }
            set { lastUpdateDateTime = value; }
        }
        public bool? IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion
    }
}
