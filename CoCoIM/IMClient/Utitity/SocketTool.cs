using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IMClient.Utitity
{
    public class SocketTool
    {
        public static void Send(Socket socket, string sendStr)
        {
            var sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendStr);
            socket.Send(sendBytes);

            string recStr = "";
            byte[] recByte = new byte[4096];
            int bytes = socket.Receive(recByte, recByte.Length, 0);
            recStr += Encoding.GetEncoding("gb2312").GetString(recByte, 0, bytes);
            System.Windows.Forms.MessageBox.Show("收到的信息:" + recStr);
        }


    }
}
