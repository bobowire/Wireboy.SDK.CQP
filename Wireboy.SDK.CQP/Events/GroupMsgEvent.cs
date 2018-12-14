using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    public class GroupMsgEvent : IGroupMsgEvent
    {
        ILogger _logger;
        public GroupMsgEvent(ILogger logger)
        {
            _logger = logger;
        }
        public void Handle(GroupMsgContext context)
        {
            //CQ.AddLog(Core.Enums.LogerLevel.Debug, "提示", context.msg);
            if (context.fromGroup == 417159195)
            {
                _logger.GroupMsg(context);
            }
            //dbContext.TestLogs.
        }
    }
}
