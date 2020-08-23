using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMServer.Session
{
    public class ChatSession : AppSession<ChatSession>
    {

        public string Id { get; set; }

        public string PassWord { get; set; }

        public bool IsLogin { get; set; }

        public DateTime LoginTime { get; set; }


        /// <summary>
        /// 消息发送
        /// </summary>
        /// <param name="message"></param>
        public override void Send(string message)
        {
            base.Send(message.SendFormat());
        }

        protected override void OnSessionStarted()
        {
            this.Send("欢迎使用聊天程序!");
        }

        protected override void OnInit()
        {
            this.Charset = Encoding.GetEncoding("gb2312");
            base.OnInit();
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            //Console.WriteLine("收到命令:" + requestInfo.Key.ToString());
            //this.Send("不知道如何处理 " + requestInfo.Key.ToString() + " 命令");
        }


        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            //this.Send($"\n\r 异常信息：{ e.Message}");
            //base.HandleException(e);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            //Console.WriteLine("链接已关闭。。。");
            base.OnSessionClosed(reason);
        }

    }
}
