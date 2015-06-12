using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IbatisLibrary.DataBasic;
using IbatisLibrary.Interface;
using IbatisLibrary.Context;
using NetworkMallModel;

namespace IbatisLibraryServices
{
    public class BeneficiaryInfoServices : BasicBill<IBeneficiaryInfo>
    {
        private static BeneficiaryInfoServices _Instance = null;

        public static BeneficiaryInfoServices Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BeneficiaryInfoServices();
                return _Instance;
            }
        }

        private BeneficiaryInfoServices()
            : base(SqlMapContextEnum.SsacWebDao)
        {

        }


        /// <summary>
        /// 插入受益人信息
        /// </summary>
        /// <param name="bInfo"></param>
        /// <returns></returns>
        public bool InsertBeneficiaryInfo(BeneficiaryInfo bInfo)
        {
            return Dao.InsertBeneficiaryInfo(bInfo);
        }

        /// <summary>
        /// 查询受益人信息
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public IList<BeneficiaryInfo> SelectBeneficiaryByOrderCode(string OrderCode)
        {
            return Dao.SelectBeneficiaryByOrderCode(OrderCode);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public bool DeleteBeneficiaryByOrderCode(string OrderCode)
        {
            return Dao.DeleteBeneficiaryByOrderCode(OrderCode);
        }

    }
}
