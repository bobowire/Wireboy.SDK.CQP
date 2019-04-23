namespace Wireboy.SDK.CQP.SdkModule.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QQAccountPools
    {
        public Guid Id { get; set; }

        public bool IsGroupMember { get; set; }

        public long QQ { get; set; }

        public string Log { get; set; }
        public string NickName { get; set; }
    }
}
