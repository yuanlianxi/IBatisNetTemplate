using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskAcquisitionLog
    {
        #region private fields
        
        private int id;
        private int taskTotalCount;
        private int taskValidCount;
        private DateTime acquisitionDateTime;
        private int isActive;
        private DateTime createDateTime;
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
        public int TaskTotalCount
        {
            get
            {
                return taskTotalCount;
            }
            set
            {
                taskTotalCount = value;
            }
        }
        public int TaskValidCount
        {
            get
            {
                return taskValidCount;
            }
            set
            {
                taskValidCount = value;
            }
        }
        public DateTime AcquisitionDateTime
        {
            get
            {
                return acquisitionDateTime;
            }
            set
            {
                acquisitionDateTime = value;
            }
        }
        public int IsActive
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
        public DateTime CreateDateTime
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
        #endregion
    }
}
