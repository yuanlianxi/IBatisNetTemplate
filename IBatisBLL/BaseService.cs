using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataAccess.Interfaces;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.SessionStore;
using IBatisNet.DataAccess.Configuration;
using IBatisBLL;

namespace IBatisBLL
{
    public class BaseService<T> where T : class
    {
        protected enum DALContextEnum 
        { 
            DefaultDAL
        }
        #region 私有变量
        
        /// <summary>
        /// DaoManager
        /// </summary>
        private IDaoManager _daoManager;

        protected IDaoManager DaoManager
        {
            get { return _daoManager; }
            set { _daoManager = value; }
        }

        protected T Dao { get; set; }

        #endregion
        //解密
        public string GetConnectionString(string connection)
        {
            return "";//DESEncrypt.Decrypt(connection, "ssac");
        }
        /// <summary>
        /// 构造器
        /// </summary>
        protected BaseService(DALContextEnum sqlMapContextEnum)
        {
            try
            {

                _daoManager = DalConfig.GetInstance().GetDaoManager(sqlMapContextEnum.ToString());   

                if (!_daoManager.LocalDataSource.ConnectionString.Contains("Data Source="))
                {
                    _daoManager.LocalDataSource.ConnectionString =
                        GetConnectionString(_daoManager.LocalDataSource.ConnectionString);
                }

                Dao = (T)_daoManager.GetDao(typeof(T));
            }
            catch (Exception ex)
            {
                ShowException(ex);
                throw ex;
            }

        }

        protected void ShowException(Exception e)
        {
            ShowException("", e);
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="target"></param>
        /// <param name="e"></param>
        protected void ShowException(string target, Exception e)
        {
            Exception ex = e;
            while (true)
            {
                if (ex == null)
                {
                    break;
                }
                string strmess = ex.Message;
                if (string.IsNullOrEmpty(strmess) && strmess.Length > 1000)
                {
                    strmess = strmess.Substring(0, 1000) + "...";
                }
                ex = ex.InnerException;
            }
        }

        protected IDao GetDao(Type type)
        {
            try
            {
                IDaoManager daoManager = DalConfig.GetInstance()._DaoManager;
                IDao dao = daoManager.GetDao(type);
                return dao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected IDaoManager GetDaoManager()
        {           
            IDaoManager daoManager = IBatisNet.DataAccess.DaoManager.GetInstance();
            //HybridWebThreadSessionStore newSessionStore = new HybridWebThreadSessionStore(daoManager.Id);
            //daoManager.SessionStore = newSessionStore;
            return daoManager;
        }

        protected void BeginTransaction()
        {
            GetDaoManager().BeginTransaction();
        }

        protected void CommitTransaction()
        {
            GetDaoManager().CommitTransaction();
        }

        protected void RollBackTransaction()
        {
            GetDaoManager().RollBackTransaction();
        }
    }
}
