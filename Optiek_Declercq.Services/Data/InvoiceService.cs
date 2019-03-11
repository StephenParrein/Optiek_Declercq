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
    class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public InvoiceService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public IList<Invoice> All()
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Invoices.GetAll().ToList();
            }
        }

        public Invoice Get(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.Invoices.Get(id);
            }
        }

        public Invoice Create(Invoice entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                unitOfWork.Invoices.Add(entity);
                return entity;
            }
        }

        public Invoice Edit(Invoice entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                //TODO validation

                var invoice = unitOfWork.Invoices.Get(entity.ID);
                if (invoice == null) { return null; }

                //TODO finish model and update the model

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return invoice; }

                return null;
            }
        }

        public bool Remove(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                var invoice = unitOfWork.Invoices.Get(id);
                if (invoice == null)
                    return false;

                unitOfWork.Invoices.Remove(invoice);

                var numberOfObjectsUpdated = unitOfWork.Complete();
                return numberOfObjectsUpdated > 0;
            }
        }
    }
}
