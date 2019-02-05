using MyWebSite.DAL.MyEntities;
using System.Data.Entity;

namespace MyWebSite.DAL
{
   public class MyWebSiteContext : DbContext
    {
        public MyWebSiteContext() : base("MyWebSiteContext")
        {

        }
        public DbSet<User> User { get; set; }
    }
}
