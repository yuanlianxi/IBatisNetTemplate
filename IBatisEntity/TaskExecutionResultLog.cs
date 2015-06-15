using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskExecutionResultLog
    {
        #region private fields

        private int id;
        private int? taskId;
        private DateTime? taskExecuteStartTime;
        private DateTime? taskExecuteEndTime;
        private int? taskDuringMilliSeconds;
        private int? taskMaxDuringMilliSeconds;
        private int? taskReturnValueLimitMax;
        private int? taskReturnValue;
        private int? taskReturnValueLimitMin;
        private bool? isWarn;
        private bool? isExcept;
        private string exceptionInfo;
        private string exceptionType;
        private DateTime? createDateTime;
        private bool? isActive;
        private int? taskState;

        
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
        public DateTime? TaskExecuteStartTime
        {
            get
            {
                return taskExecuteStartTime;
            }
            set
            {
                taskExecuteStartTime = value;
            }
        }
        public DateTime? TaskExecuteEndTime
        {
            get
            {
                return taskExecuteEndTime;
            }
            set
            {
                taskExecuteEndTime = value;
            }
        }
        public int? TaskDuringMilliSeconds
        {
            get
            {
                return taskDuringMilliSeconds;
            }
            set
            {
                taskDuringMilliSeconds = value;
            }
        }
        public int? TaskMaxDuringMilliSeconds
        {
            get
            {
                return taskMaxDuringMilliSeconds;
            }
            set
            {
                taskMaxDuringMilliSeconds = value;
            }
        }
        public int? TaskReturnValueLimitMax
        {
            get
            {
                return taskReturnValueLimitMax;
            }
            set
            {
                taskReturnValueLimitMax = value;
            }
        }
        public int? TaskReturnValue
        {
            get
            {
                return taskReturnValue;
            }
            set
            {
                taskReturnValue = value;
            }
        }
        public int? TaskReturnValueLimitMin
        {
            get
            {
                return taskReturnValueLimitMin;
            }
            set
            {
                taskReturnValueLimitMin = value;
            }
        }
        public bool? IsWarn
        {
            get
            {
                return isWarn;
            }
            set
            {
                isWarn = value;
            }
        }
        public bool? IsExcept
        {
            get
            {
                return isExcept;
            }
            set
            {
                isExcept = value;
            }
        }
        public string ExceptionInfo
        {
            get
            {
                return exceptionInfo;
            }
            set
            {
                exceptionInfo = value;
            }
        }
        public string ExceptionType
        {
            get
            {
                return exceptionType;
            }
            set
            {
                exceptionType = value;
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
        public int? TaskState
        {
            get { return taskState; }
            set { taskState = value; }
        }
        #endregion

    }
}
