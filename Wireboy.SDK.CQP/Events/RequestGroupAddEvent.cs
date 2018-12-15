using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Events
{
    public class RequestAddGroupEvent : IRequestAddGroupEvent
    {
        ILogger _logger;
        public RequestAddGroupEvent(ILogger logger)
        {
            _logger = logger;
        }
        public void Handle(RequestAddGroupContext context)
        {
        }
    }
}
