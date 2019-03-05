using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.Includes;
using Optiek_Declercq.Repository.Repos;
using Optiek_Declercq.Services.Contracts;
using Optiek_Declercq.Services.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Services.Data
{
    public class CustomerService
    {

        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CustomerService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public CustomerService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IList<Customer> All()
        {
            return All(null);
        }

        public IList<Customer> All(CustomerIncludes includes)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Customers.All(includes).ToList();
            }
        }

        public Customer Get(int id)
        {
            return Get(id, null);
        }

        public Customer Get(int id, CustomerIncludes includes)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Customers.Get(id, includes);
            }
        }

    }
}
