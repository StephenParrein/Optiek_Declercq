using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Repository.Contracts;
using Optiek_Declercq.Repository.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.Repos
{
    public class InvoiceRuleRepository : Repository<InvoiceRule>, IInvoiceRuleRepository
    {
        public InvoiceRuleRepository(DbContext context) : base(context)
        {
        }
    }
}
