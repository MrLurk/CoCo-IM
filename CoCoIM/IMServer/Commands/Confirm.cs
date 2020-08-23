using IMServer.DataCenter;
using IMServer.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.SocketService.Commands
{
    public class Confirm : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        { 
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                string modelId = requestInfo.Parameters[0]; 
                Console.WriteLine($"用户{session.Id} 已确认，收到消息{modelId}");
                ChatDataManager.Remove(session.Id, modelId);
            }
            else
            {
                session.Send("参数错误");
            }
        }
    }
}
