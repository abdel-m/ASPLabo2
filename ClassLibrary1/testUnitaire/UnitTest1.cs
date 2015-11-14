using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using ClassLibrary1;
using System.Linq;

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
            CompanyContext cpContext = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B7;User ID=IG3B7;Password=pwUserdb74");
            cpContext.Customers.Add(abdel);
            cpContext.SaveChanges();
        }

        
        public void TestMethod2()
        {

            CompanyContext compContext = new CompanyContext(@"Data Source=vm-sql.iesn.be\Stu3IG;Initial Catalog=DBIG3B7;User ID=IG3B7;Password=pwUserdb74");
            Assert.IsTrue(compContext.Customers.Count() >= 1);
        }
    }
}
