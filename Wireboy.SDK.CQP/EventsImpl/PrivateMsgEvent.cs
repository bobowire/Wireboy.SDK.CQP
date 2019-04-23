using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Models;
using Wireboy.SDK.CQP.SdkEvents;
using Wireboy.SDK.CQP.SdkModule.DataBase;

namespace Wireboy.SDK.CQP.EventsImpl
{
    public class PrivateMsgEvent : IPrivateMsgEvent
    {
        SqlServerDb m_dbContext;
        public PrivateMsgEvent(SqlServerDb dbContext)
        {
            m_dbContext = dbContext;
        }
        public void Handle(PrivateMsgContext context)
        {
            if (context.fromQQ == 1195585531)
            {
                //通过下面直接回复
                context.fromQQ.SendPrivateMsg(context.msg);

                //将私聊消息转发到QQ群
                long groupId = 417159195;//QQ群号码
                groupId.SendGroupMsg(context.msg);

                //发送新消息
                string newMsg = "";
                newMsg.AddImage("C://img01.png")
                    .AddEmoji(Core.Enums.Emoji.可爱)
                    .AddMsg("wireboy最帅！")
                    .SendPrivateMsg(1195585531);

                //当然，你也可以直接调用接口发送消息
                CQ.SendPrivateMsg(1195585531, "wireboy最帅！");
            }
        }
    }
}
