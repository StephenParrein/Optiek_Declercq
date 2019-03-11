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
    class ErrorLogService : IErrorLogService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ErrorLogService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public IList<ErrorLog> All()
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.ErrorLogs.GetAll().ToList();
            }
        }

        public ErrorLog Get(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.ErrorLogs.Get(id);
            }
        }

        public ErrorLog Create(ErrorLog entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                unitOfWork.ErrorLogs.Add(entity);
                return entity;
            }
        }

        public ErrorLog Edit(ErrorLog entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                //TODO validation

                var errorLogs = unitOfWork.ErrorLogs.Get(entity.ID);
                if (errorLogs == null) { return null; }

                errorLogs.Message = entity.Message;

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return errorLogs; }

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
