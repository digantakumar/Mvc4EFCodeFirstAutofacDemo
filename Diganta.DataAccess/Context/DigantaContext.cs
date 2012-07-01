using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Diganta.Domain.Entities;

namespace Diganta.DataAccess.Context
{
    public class DigantaContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        //Remove this after creating the database   
        public DigantaContext() : base("name=DigantaContext") { }
    }

    //public class DigantaInitializer : DropCreateDatabaseIfModelChanges<DigantaContext>{}
    //Turnoff Db initializer on production
//    <appSettings>
//<add key="DatabaseInitializerForType
//DataLayer.TwitterContext, DataAccess”
//value="Disabled" />
//</appSettings>
}
