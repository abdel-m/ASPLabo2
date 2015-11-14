using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using ClassLibrary1;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace testUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());
            Customer abdel = new Customer();
            abdel.City = "Couvin";
            CompanyContext cpContext = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B72;User ID=IG3B7;Password=pwUserdb74");
            cpContext.Customers.Add(abdel);
            cpContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void TestMethod2()
        {
            /*
            CompanyContext compContext = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B72;User ID=IG3B7;Password=pwUserdb74");
            Assert.IsTrue(compContext.Customers.Count() >= 1);
            */

            var contextJohn = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B72;User ID=IG3B7;Password=pwUserdb74");
            var clientJohn = contextJohn.Customers.First();

            var contextSarah = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B72;User ID=IG3B7;Password=pwUserdb74");
            var clientSarah = contextSarah.Customers.First();

            clientJohn.AccountBalance += 1000;
            contextJohn.SaveChanges();

            clientSarah.AccountBalance += 2000;
            contextSarah.SaveChanges();

        }
    }
}
