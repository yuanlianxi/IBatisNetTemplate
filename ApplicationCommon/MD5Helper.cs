using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCommon
{
    public class MD5Helper
    {
        public static string GetMD5(string sDataIn,bool IsUpper = true)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            string format = (IsUpper ? "X" : "x") + "2";
            for (int i = 0; i < bytHash.Length; i++)
            {

                sTemp += bytHash[i].ToString(format);
            }
            return sTemp;
        } 
    }
}
