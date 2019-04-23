namespace Wireboy.SDK.CQP.SdkModule.DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlServerDb : DbContext
    {
        public SqlServerDb()
            : base("name=SqlServerDb")
        {
        }

        public virtual DbSet<QQAccountPools> QQAccountPools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
