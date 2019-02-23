using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optiek_Declercq.Model.Models;

namespace Optiek_Declercq.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("connectionstring")
        {
            //Init DbContext
        }

        DbSet<CustomerModel> customers;
        DbSet<AddressModel> addresses;

    }
}
