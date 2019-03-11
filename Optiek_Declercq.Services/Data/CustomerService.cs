using Optiek_Declercq.Exceptions;
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
            CustomerIncludes includes = new CustomerIncludes();
            includes.AddressDetails = true;
            includes.CompanyDetails = true;

            return All(includes);
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

        public Customer Edit(Customer entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                if (!new CustomerValidation().CheckCustomerModel(entity)) { return null; }

                var customer = unitOfWork.Customers.Get(entity.ID);
                if (customer == null) { return null; }

                customer.Name = entity.Name;
                customer.FirstName = customer.FirstName;
                customer.AddressID = entity.AddressID;
                customer.CompanyID = entity.CompanyID;
                customer.EmailAdress = entity.EmailAdress;
                customer.PhoneNumber = entity.PhoneNumber;

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return customer; }

                return null;
            }
        }

        public bool Remove(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                var customer = unitOfWork.Customers.Get(id);
                if (customer == null)
                    return false;

                unitOfWork.Customers.Remove(customer);

                var numberOfObjectsUpdated = unitOfWork.Complete();
                return numberOfObjectsUpdated > 0;
            }
        }
    }
}
