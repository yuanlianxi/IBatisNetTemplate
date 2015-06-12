using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBatisEntity
{
    public class TaskInfo
    {
        #region private fields

        private int id;


        private int method;


        private string content;


        private string extend;


        private DateTime createDateTime;


        private DateTime lastUpdateDateTime;


        private bool isActive;

        
        #endregion

        #region public properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Method
        {
            get { return method; }
            set { method = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string Extend
        {
            get { return extend; }
            set { extend = value; }
        }
        public DateTime CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }
        public DateTime LastUpdateDateTime
        {
            get { return lastUpdateDateTime; }
            set { lastUpdateDateTime = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        #endregion
    }
}
