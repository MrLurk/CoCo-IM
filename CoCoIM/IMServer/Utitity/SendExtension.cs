using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SendExtension
    {
        /// <summary>
        /// 发送增加 \r\n
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string SendFormat(this string words)
        {
            return $"{words}\r\n";
        }
    }
}
