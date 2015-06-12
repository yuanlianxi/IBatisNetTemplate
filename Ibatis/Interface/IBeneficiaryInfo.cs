using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkMallModel;

namespace IbatisLibrary.Interface
{
    public interface IBeneficiaryInfo
    {
        /// <summary>
        /// 插入受益人信息
        /// </summary>
        /// <param name="bInfo"></param>
        /// <returns></returns>
        bool InsertBeneficiaryInfo(BeneficiaryInfo bInfo);

        /// <summary>
        /// 查询受益人信息
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        IList<BeneficiaryInfo> SelectBeneficiaryByOrderCode(string OrderCode);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        bool DeleteBeneficiaryByOrderCode(string OrderCode);
    }
}
