using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskWarningLog
    {
        #region private fields


        private int id;
        private int? taskId;
        private string warnInfo;
        private DateTime? createDateTime;
        private bool? isActive;
        #endregion

        #region public properties

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int? TaskId
        {
            get
            {
                return taskId;
            }
            set
            {
                taskId = value;
            }
        }
        public string WarnInfo
        {
            get
            {
                return warnInfo;
            }
            set
            {
                warnInfo = value;
            }
        }
        public DateTime? CreateDateTime
        {
            get
            {
                return createDateTime;
            }
            set
            {
                createDateTime = value;
            }
        }
        public bool? IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
        #endregion
    }
}
