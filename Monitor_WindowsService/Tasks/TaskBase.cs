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
        public enum TaskState{
            Executing
            ,End
            ,Exception

        }
        #region private Fields

        private int taskId;
        private int overTimeMilliSeconds;
        private int minValue;
        private int maxValue;
        private Exception error;

        private object returnValue;
        private DateTime startDateTime;
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
        protected object ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        protected DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        
        #endregion
        #region public method
        public abstract void Execute();
        public TaskState State() {

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

        public  void Abort()
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }
        #endregion
    }
}
