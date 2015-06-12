using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IbatisLibrary.Interface;
using IbatisLibrary.Dao;
using NetworkMallModel;
using IbatisLibrary.Log;
using System.Collections;

namespace IbatisLibrary.DaoAccess
{
    public class BeneficiaryInfoDao : BasicDao, IBeneficiaryInfo
    {
        /// <summary>
        /// 插入受益人信息
        /// </summary>
        /// <param name="bInfo"></param>
        /// <returns></returns>
        public bool InsertBeneficiaryInfo(BeneficiaryInfo bInfo)
        {
            try
            {
                bInfo.ID = Convert.ToInt32(ExecuteInsert("InsertBeneficiaryInfo", bInfo));
                if (bInfo.ID > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                DbLog.LogDao.InsertMallLog(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 查询受益人信息
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public IList<BeneficiaryInfo> SelectBeneficiaryByOrderCode(string OrderCode)
        {
            try
            {
                return ExecuteQueryForList<BeneficiaryInfo>("SelectBeneficiaryByOrderCode", OrderCode);
            }
            catch (Exception ex)
            {
                DbLog.LogDao.InsertMallLog(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public bool DeleteBeneficiaryByOrderCode(string OrderCode)
        {
            try
            {
                ExecuteDelete("DeleteBeneficiaryByOrderCode", OrderCode);
                return true;
            }
            catch (Exception ex)
            {
                DbLog.LogDao.InsertMallLog(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
                return false;
            }
        }
    }
}
