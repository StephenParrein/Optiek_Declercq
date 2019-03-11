using Optiek_Declercq.Model.Contracts;
using Optiek_Declercq.Repository.Contracts;
using Optiek_Declercq.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OptiekDbContext _context;

        public UnitOfWork()
        {
            _context = new OptiekDbContext();
            Addresses = new AddressRepository(_context);
            Companies = new CompanyRepository(_context);
            Customers = new CustomerRepository(_context);
            ErrorLogs = new ErrorLogRepository(_context);
            Invoices = new InvoiceRepository(_context);
            InvoiceRules = new InvoiceRuleRepository(_context);
        }

        public IAddressRepository Addresses { get; }

        public ICompanyRepository Companies { get; }

        public ICustomerRepository Customers { get; }

        public IErrorLogRepository ErrorLogs { get; }

        public IInvoiceRepository Invoices { get; }

        public IInvoiceRuleRepository InvoiceRules { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
