using System.Data.Entity;
using Diganta.Domain.Entities;

namespace Diganta.Website.Models.Diganta
{
    public class WebsiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Diganta.Website.Models.Diganta.WebsiteContext>());

        public WebsiteContext() : base("name=WebsiteContext")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
