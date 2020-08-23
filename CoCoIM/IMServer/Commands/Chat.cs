using IMServer.DataCenter;
using IMServer.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMServer.Commands
{
    public class Chat : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            // 还是传递两个参数  1、 要发给谁 ToId    2、消息内容
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                string toId = requestInfo.Parameters[0];
                string message = requestInfo.Parameters[1];
                ChatSession toSession = session.AppServer.GetAllSessions().FirstOrDefault(a => toId.Equals(a.Id));
                 
                string modelId = Guid.NewGuid().ToString();
                if (toSession != null) // 说过之前有用户用这个Id 登录过
                {
                    toSession.Send($"{session.Id} 给你发消息：{message} ");
                    ChatDataManager.Add(toId, new ChatModel()
                    {
                        FromId = session.Id,
                        ToId = toId,
                        Message = message,
                        Id = modelId,
                        State = 1,// 待确认
                        CreateTime = DateTime.Now
                    });
                }
                else
                {
                    ChatDataManager.Add(toId, new ChatModel()
                    {
                        FromId = session.Id,
                        ToId = toId,
                        Message = message,
                        Id = modelId,
                        State = 0,// 未发送
                        CreateTime = DateTime.Now
                    }); 
                    session.Send("消息未发送成功");
                }
            }
            else
            {
                session.Send("参数错误");
            }
        }
    }
}
