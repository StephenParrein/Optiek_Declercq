using Optiek_Declercq.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.EF
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        ICompanyRepository Companies { get; }
        ICustomerRepository Customers { get; }
        IErrorLogRepository ErrorLogs { get; }
        IInvoiceRuleRepository Invoices { get; }
        IInvoiceRuleRepository InvoiceRules { get; }
       
        int Complete();
    }
}
