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
    public class Login : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {

            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                var loginId = requestInfo.Parameters[0];
                var passWord = requestInfo.Parameters[1];

                #region 权限校验
                var info = TestDataSource.Source.FirstOrDefault(x => x.Key == loginId);
                if (info.Key == null)
                {
                    session.Send("登陆失败,账户或密码错误!");
                    return;
                }
                if (info.Value != passWord)
                {
                    session.Send("登陆失败,账户或密码错误!");
                    return;
                }
                #endregion

                session.Id = requestInfo.Parameters[0];
                session.PassWord = requestInfo.Parameters[1];
                session.IsLogin = true;
                session.LoginTime = DateTime.Now;

                session.Send("登录成功");


                // 获取当前登录用户的离线消息 
                ChatDataManager.SendLogin(session.Id, c =>
                {
                    session.Send($"{c.FromId} 给你发送离线消息：{c.Message} ");
                });
            }

        }
    }
}
