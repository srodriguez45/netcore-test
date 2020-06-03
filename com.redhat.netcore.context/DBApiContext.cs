using com.redhat.netcore.models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace com.redhat.netcore.context
{
    public class DBApiContext : DbContext
    {

        public IConfigurationRoot Configuration { get; }
        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }


        public DBApiContext(DbContextOptions<DBApiContext> options) : base(options)
        {
        }

    }
}
