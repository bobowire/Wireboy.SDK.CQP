using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.Events;

namespace Wireboy.SDK.CQP
{
    public interface ILogger
    {
        void GroupMsg(GroupMsgContext groupMsgContext);
    }
}
