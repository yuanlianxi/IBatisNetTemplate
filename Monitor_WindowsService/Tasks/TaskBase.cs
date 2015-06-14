using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monitor_WindowsService.Tasks
{
    public abstract class TaskBase
    {
        public enum TaskState
        {
            Executing
            ,
            End
                , Exception

        }
        #region private Fields

        private int taskId;
        private int overTimeMilliSeconds;
        private int minValue;
        private int maxValue;
        private Exception error;

        private int returnValue;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private int duringMilliSeconds;
        private int tryTimes;

        
        #endregion

        #region protected fields

        protected Task task;
        protected CancellationTokenSource tokenSource;
        #endregion



        #region public properties
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        public int OverTimeMilliSeconds
        {
            get
            {
                return overTimeMilliSeconds;
            }
            set
            {
                overTimeMilliSeconds = value;
            }
        }
        public int MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
            }
        }
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
            }
        }

        public Exception Error
        {
            get { return error; }
            set { error = value; }
        }
        public  int ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        public  DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public int DuringMilliSeconds
        {
            get { return duringMilliSeconds; }
            set { duringMilliSeconds = value; }
        }
        public int TryTimes
        {
            get { return tryTimes; }
            set { tryTimes = value; }
        }
        #endregion
        #region public method
        public abstract void Execute();
        public TaskState State()
        {
            if (task.Status == TaskStatus.Faulted)
            {
                return TaskState.Exception;
            }
            if (task.Status == TaskStatus.RanToCompletion)
            {
                return TaskState.End;
            }
            return TaskState.Executing;
        }

        public void Abort()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }
        #endregion
    }
}
