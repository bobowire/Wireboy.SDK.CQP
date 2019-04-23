using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Models;
using Wireboy.SDK.CQP.SdkEvents;
using Wireboy.SDK.CQP.SdkModule.DataBase;

namespace Wireboy.SDK.CQP.EventsImpl
{
    public class GroupMsgEvent : IGroupMsgEvent
    {
        SqlServerDb m_dbContext;
        public GroupMsgEvent(SqlServerDb dbContext)
        {
            m_dbContext = dbContext;
        }
        public void Handle(GroupMsgContext context)
        {
            if (context.fromGroup == 417159195 || context.fromGroup == 706310655)
            {
                //_logger.GroupMsg(context);
            }
        }
    }
}
