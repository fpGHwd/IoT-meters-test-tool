using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcentratorTest.Tools
{
    class Check
    {
        /*
        /// <summary>
        /// Mac校验
        /// </summary>
        /// <param name="in_str"></param>
        /// <param name="in_str_len"></param>
        /// <param name="macstr"></param>
        public static void GetCheckCode(string in_str, int in_str_len, ref string macstr)
        {
            int k, n, len;
            char[] tmp_str = new char[1024];
            char[] result_str = new char[9];

            len = in_str_len;
            k = len % 8;
            n = 8 - k;

            for (int i = 0; i < tmp_str.Length; i++)
            {
                if (i < len)
                {
                    tmp_str[i] = in_str[i];
                }
                else if (i == len)
                {
                    tmp_str[i] = (char)0x7f;
                }
                else if (i > len)
                {
                    tmp_str[i] = (char)0x00;
                }
            }

            len += n;

            for (int i = 0; i < len; )
            {
                for (int j = 0; j < 8; j++)
                {
                    result_str[j] ^= tmp_str[i];
                    i = i + 1;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (result_str[i] >= 0x80) result_str[i] = (char)(result_str[i] ^ 0x80);
                if (result_str[i] == 0x0d) result_str[i] = (char)0x4d;
                if (result_str[i] == 0x0a) result_str[i] = (char)0x4a;
                if (result_str[i] == 0x3a) result_str[i] = (char)0x7a;
                if (result_str[i] == 0x7c) result_str[i] = (char)0x3c;
                if (result_str[i] == 0x00) result_str[i] = (char)0x40;
            }

            char[] macchar = new char[8];
            for (int i = 0; i < macchar.Length; i++)
            {
                macchar[i] = result_str[i];
            }
            macstr = (new StringBuilder()).Append(macchar).ToString();
        }
        */



        /// <summary>
        /// CRC16校验
        /// </summary>
        /// <param name="data">需要计算校验的byte数组</param>
        /// <param name="len">byte数组长度</param>
        /// <returns>2字节校验码</returns>
        public static byte[] crc16(byte[] data, int len)
        {
            byte[] temdata = new byte[2];
            int xda, xdapoly;
            int i, j, xdabit;
            xda = 0xFFFF;
            xdapoly = 0xA001;
            for (i = 0; i < len; i++)
            {
                xda ^= data[i];
                for (j = 0; j < 8; j++)
                {
                    xdabit = (int)(xda & 0x01);
                    xda >>= 1;
                    if (xdabit == 1)
                        xda ^= xdapoly;
                }
            }
            temdata[0] = (byte)(xda & 0xFF);
            temdata[1] = (byte)(xda >> 8);
            temdata.ToString();
            return temdata;
        }



        /// <summary>
        /// 通过最终命令报文来获取crc校验
        /// </summary>
        /// <param name="lastcmd"></param>
        /// <returns>两字节16进制字符串crc校验结果</returns>
        public static string getCrcStr(string lastcmd)
        {
            string crcstr = "0000";
            string bytesStr = lastcmd.Replace("|", "").Replace(" ", "");//差不多的字符串

            try
            {
                if (bytesStr.Length % 2 == 0)
                {
                    byte[] bytes = new byte[bytesStr.Length / 2 - 3];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        string str = bytesStr.Substring(i * 2, 2);
                        bytes[i] = Convert.ToByte(str, 16);
                    }

                    if (bytes != null && bytes.Length != 0)
                    {
                        byte[] bytesreturn = crc16(bytes, bytes.Length);
                        crcstr = bytesreturn[0].ToString("X2").PadLeft(2, '0') + bytesreturn[1].ToString("X").PadLeft(2, '0');
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return crcstr;
        }
    }
}
