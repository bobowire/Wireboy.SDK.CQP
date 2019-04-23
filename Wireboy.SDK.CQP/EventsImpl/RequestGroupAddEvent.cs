using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wireboy.SDK.CQP.SdkEvents;
using Wireboy.SDK.CQP.SdkModule.DataBase;

namespace Wireboy.SDK.CQP.EventsImpl
{
    public class RequestAddGroupEvent : IRequestAddGroupEvent
    {
        SqlServerDb m_dbContext;
        public RequestAddGroupEvent(SqlServerDb dbContext)
        {
            m_dbContext = dbContext;
        }
        public void Handle(RequestAddGroupContext context)
        {
        }
    }
}
