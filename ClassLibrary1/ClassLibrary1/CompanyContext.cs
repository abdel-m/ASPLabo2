using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CompanyContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public CompanyContext(string connectionString) : base(connectionString)
        {

        }

        public CompanyContext()
        {
            // TODO: Complete member initialization
        }
    }
}
