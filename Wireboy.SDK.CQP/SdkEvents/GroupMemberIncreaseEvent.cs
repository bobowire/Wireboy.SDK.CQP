using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    public class GroupMemberIncreaseEvent : IGroupMemberIncreaseEvent
    {
        ILogger _logger;
        public GroupMemberIncreaseEvent(ILogger logger)
        {
            _logger = logger;
        }
        public void Handle(GroupMemberIncreaseContext context)
        {
            if (context.fromGroup == 417159195)
            {
                CQ.GetGroupMemberInfoV2(context.fromGroup, context.beingOperateQQ, false);
            }
        }
    }
}
