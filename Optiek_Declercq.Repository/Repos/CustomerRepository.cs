using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.Contracts;
using Optiek_Declercq.Repository.EF;
using Optiek_Declercq.Repository.Includes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.Repos
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> All(CustomerIncludes includes)
        {
            var query = Context.Set<Customer>().AsQueryable();
            query = AddIncludes(query, includes);
            return query.AsEnumerable();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate, CustomerIncludes includes)
        {
            var query = Context.Set<Customer>().AsQueryable();
            query = AddIncludes(query, includes);
            return query.Where(predicate).AsEnumerable();
        }

        public Customer Get(int id, CustomerIncludes includes)
        {
            var query = Context.Set<Customer>().AsQueryable();
            query = AddIncludes(query, includes);
            query = query.Where(i => i.ID == id);
            return query.FirstOrDefault();
        }

        private IQueryable<Customer> AddIncludes(IQueryable<Customer> query, CustomerIncludes includes)
        {
            if (includes == null)
                return query;

            if (includes.AddressDetails)
                query = query.Include(i => i.Address);

            if (includes.CompanyDetails)
            {
                query = query.Include(i => i.Company);
            }

            return query;
        }

        public OptiekDbContext OptiekDbContext => Context as OptiekDbContext;
    }
}
