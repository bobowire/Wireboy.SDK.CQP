using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Models;

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
            if (context.fromGroup == 417159195 || context.fromGroup == 706310655)
            {
                _logger.GroupMsg(context);
            }
        }
    }
}
