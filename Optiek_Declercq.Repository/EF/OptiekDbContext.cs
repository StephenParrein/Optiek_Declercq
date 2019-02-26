using Optiek_Declercq.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.EF
{
    class OptiekDbContext : DbContext
    {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ErrorLog> Errors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceRule> InvoiceRules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Makes sure nothing gets initialized. We do this ourselves
            Database.SetInitializer<OptiekDbContext>(null);

            //We manage our own deletes, not EF
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Table names are not Plural! (collections are, however)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
