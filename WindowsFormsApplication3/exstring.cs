using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcentratorTest.Tools
{
    class Tools
    {
        /// <summary>
        /// 低字节在前 高字节在后 对字符串进行翻转
        /// </summary>
        /// <param name="str">需要翻转的16进制字符串</param>
        /// <returns></returns>
        public static string GetHexData(string str)
        {
            string strres = "";

            for (int i = str.Length / 2 - 1; i >= 0; i--)
            {
                strres += str.Substring(i * 2, 2);
            }

            return strres;
        }



        #region  工具方法
        /*********************************工具方法**************************************/
        /// <summary> 
        /// 字符串转16进制字节数组 
        /// </summary> 
        /// <param name="hexString"></param> 
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            hexString = hexString.Replace("-", "");
            hexString = hexString.Replace(":", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += " " + bytes[i].ToString("X2");
                }
            }
            return returnStr.Trim();
        }


        /// <summary>
        /// 16进制字符串转10进制字符串
        /// </summary>
        /// <returns></returns>
        /*
        public static string hexStrToDecStr(string hexstr)
        {
            Convert.ToInt32(hexstr, 16);
        }
        */

        #endregion
    }
}
