using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Services.Contracts;
using Optiek_Declercq.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Services.Data
{
    class CompanyService : ICompanyService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CompanyService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public IList<Company> All()
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Companies.GetAll().ToList();
            }
        }

        public Company Get(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Companies.Get(id);
            }
        }

        public Company Create(Company entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                unitOfWork.Companies.Add(entity);
                return entity;
            }
        }

        public Company Edit(Company entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                //TODO validation

                var company = unitOfWork.Companies.Get(entity.ID);
                if (company == null) { return null; }

                company.AddressID = entity.AddressID;
                company.CompanyName = entity.CompanyName;
                company.CompanyProFormaBilling = entity.CompanyProFormaBilling;
                company.CompanyVatNumber = entity.CompanyVatNumber;

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return company; }

                return null;
            }
        }

        public bool Remove(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                var address = unitOfWork.Addresses.Get(id);
                if (address == null)
                    return false;

                unitOfWork.Addresses.Remove(address);

                var numberOfObjectsUpdated = unitOfWork.Complete();
                return numberOfObjectsUpdated > 0;
            }
        }
    }
}
