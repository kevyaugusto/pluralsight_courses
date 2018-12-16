namespace FullLogging.Console.DbContexts
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FullLoggingDb : DbContext
    {
        public FullLoggingDb()
            : base("name=FullLoggingConnection")
        {
        }

        public virtual DbSet<Models.Customer> Customers { get; set; }
    }

}