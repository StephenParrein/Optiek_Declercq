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
    class AddressService : IAddressService
    {

        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public AddressService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public IList<Address> All()
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Addresses.GetAll().ToList();
            }
        }

        public Address Get(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Addresses.Get(id);
            }
        }

        public Address Create(Address entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                unitOfWork.Addresses.Add(entity);
                return entity;
            }
        }

        public Address Edit(Address entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                //TODO validation

                var address = unitOfWork.Addresses.Get(entity.ID);
                if (address == null) { return null; }

                address.City = entity.City;
                address.PostCode = entity.PostCode;
                address.StreetWithNumber = entity.StreetWithNumber;

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return address; }

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
