using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Diganta.DataAccess.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Diganta.Website.Tests
{
    [TestClass()]
    public class DigantaContextTest
    {
        public DigantaContextTest()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DigantaContext>());
        }

        [TestMethod]
        public void CreatingDbFirstTime()
        {
            var callDa = new DigantaContext();
            var someResult = callDa.Blogs.ToList();
        }
    }
}
