using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Core.Models;

namespace Wireboy.SDK.CQP.Events
{
    public class PrivateMsgEvent : IPrivateMsgEvent
    {
        ILogger _logger;
        public PrivateMsgEvent(ILogger logger)
        {
            _logger = logger;
        }
        public void Handle(PrivateMsgContext context)
        {
            if (context.fromQQ == 1195585531)
            {
                StrangerInfo info = CQ.GetStrangerInfo(context.fromQQ, false);
            }
        }
    }
}
