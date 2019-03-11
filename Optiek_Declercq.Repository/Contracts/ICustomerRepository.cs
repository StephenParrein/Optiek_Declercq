using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.EF;
using Optiek_Declercq.Repository.Includes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> All(CustomerIncludes includes);
        IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate, CustomerIncludes includes);
        Customer Get(int id, CustomerIncludes includes);
    }
}
