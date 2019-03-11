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
    class InvoiceRuleService : IInvoiceRuleService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public InvoiceRuleService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public IList<InvoiceRule> All()
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.InvoiceRules.GetAll().ToList();
            }
        }

        public InvoiceRule Get(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                return unitOfWork.InvoiceRules.Get(id);
            }
        }

        public InvoiceRule Create(InvoiceRule entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                unitOfWork.InvoiceRules.Add(entity);
                return entity;
            }
        }

        public InvoiceRule Edit(InvoiceRule entity)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                //TODO validation

                var invoiceRule = unitOfWork.InvoiceRules.Get(entity.ID);
                if (invoiceRule == null) { return null; }

                //TODO finish model and update the model

                var numberOfObjectsUpdated = unitOfWork.Complete();
                if (numberOfObjectsUpdated > 0) { return invoiceRule; }

                return null;
            }
        }

        public bool Remove(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.CreateInstance())
            {
                var invoiceRule = unitOfWork.InvoiceRules.Get(id);
                if (invoiceRule == null)
                    return false;

                unitOfWork.InvoiceRules.Remove(invoiceRule);

                var numberOfObjectsUpdated = unitOfWork.Complete();
                return numberOfObjectsUpdated > 0;
            }
        }
    }
}
