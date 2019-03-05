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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Company> All(CompanyIncludes includes)
        {
            var query = Context.Set<Company>().AsQueryable();
            query = AddIncludes(query, includes);
            return query.AsEnumerable();
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate, CompanyIncludes includes)
        {
            var query = Context.Set<Company>().AsQueryable();
            query = AddIncludes(query, includes);
            return query.Where(predicate).AsEnumerable();
        }

        public Company Get(int id, CompanyIncludes includes)
        {
            var query = Context.Set<Company>().AsQueryable();
            query = AddIncludes(query, includes);
            query = query.Where(i => i.ID == id);
            return query.FirstOrDefault();
        }
        private IQueryable<Company> AddIncludes(IQueryable<Company> query, CompanyIncludes includes)
        {
            if (includes == null)
                return query;

            if (includes.AddressDetails)
                query = query.Include(i => i.Address);

            return query;
        }

        public OptiekDbContext OptiekDbContext => Context as OptiekDbContext;
    }
}
