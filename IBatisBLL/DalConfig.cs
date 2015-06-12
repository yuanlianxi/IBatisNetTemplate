using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.Common.Utilities;
using IBatisNet.DataAccess.Configuration;
using IBatisNet.DataAccess;

namespace IBatisBLL
{
    public class DalConfig
    {
        static private object _synRoot = new Object();
        static private DalConfig _instance;
        private IDaoManager _daoManager = null;

        /// <summary>
        /// 防止实例化，只保留似有构造函数
        /// </summary>
        private DalConfig() { }

        /// <summary>
        /// 获得DalConfig实例
        /// </summary>
        /// <returns></returns>
        static public DalConfig GetInstance()
        {
            if (_instance == null)
            {
                lock (_synRoot)
                {
                    if (_instance == null)
                    {
                        ConfigureHandler handler = new ConfigureHandler(DalConfig.Reset);
                        try
                        {
                            // DaoManager.ConfigureAndWatch(handler);
                            DomDaoManagerBuilder builder = new DomDaoManagerBuilder();
                            builder.ConfigureAndWatch("dao.config", handler);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        _instance = new DalConfig();

                        _instance._daoManager = IBatisNet.DataAccess.DaoManager.GetInstance();
                        //异步
                        //HybridWebThreadSessionStore newSessionStore = new HybridWebThreadSessionStore(_instance._daoManager.Id);
                        //_instance._daoManager.SessionStore = newSessionStore;
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// 重设实例，如果SqlMap.Config和dao.config配置文件发送改变，可调用此方法重新加载
        /// </summary>
        /// <param name="obj"></param>
        static public void Reset(object obj)
        {
            _instance = null;
        }

        /// <summary>
        /// 重设实例，如果SqlMap.Config和dao.config配置文件发送改变，可调用此方法重新加载
        /// </summary>
        static public void Reset()
        {
            _instance = null;
        }

        public IDaoManager _DaoManager
        {
            get
            {
                return _daoManager;
            }
        }

        public IDaoManager GetDaoManager(string contextName)
        {
            IDaoManager IDAO =
 IBatisNet.DataAccess.DaoManager.GetInstance(contextName);
            // SessionStoreFactory.GetSessionStore("");
            //异步
            //HybridWebThreadSessionStore newSessionStore = new HybridWebThreadSessionStore(IDAO.Id);
            //IDAO.SessionStore = newSessionStore;

            return IDAO;
        }
    }
}
