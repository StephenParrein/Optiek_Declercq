using Optiek_Declercq.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Optiek_Declercq.Exceptions
{
    public class CustomerValidation
    {
        public bool CheckCustomerModel(Customer customer)
        {
            CheckCustomerName(customer.Name);
            CheckCustomerFirstName(customer.FirstName);

            return true;
        }

        private void CheckCustomerName(string name)
        {
            //Validation for the customer last name
            if (name == null) { throw new ApplicationException().CustomerLastNameNull; }

            string customerName = name.Trim();

            if (customerName.Equals("")) { throw new ApplicationException().CustomerLastNameEmpty; }
            if (customerName.Length < 2) { throw new ApplicationException().CustomerLastNameToShort; }
            if (customerName.Length > 100) { throw new ApplicationException().CustomerLastNameToLong; }
            if (Regex.IsMatch(customerName, @"^[A-Za-z0-9_']+\s?,\s?[A-Za-z0-9_']+"))
            { throw new ApplicationException().CustomerLastNameInvalid; }
        }
        private void CheckCustomerFirstName(string firstName)
        {
            if (firstName == null) { throw new ApplicationException().CustomerFirstNameNull; }

            string customerFirstName = firstName.Trim();

            if (customerFirstName.Equals("")) { throw new ApplicationException().CustomerFirstNameEmpty; }
            if (customerFirstName.Length < 2) { throw new ApplicationException().CustomerFirstNameToShort; }
            if (customerFirstName.Length > 100) { throw new ApplicationException().CustomerFirstNameToLong; }
            if (Regex.IsMatch(customerFirstName, @"^[A-Za-z0-9_']+\s?,\s?[A-Za-z0-9_']+"))
            { throw new ApplicationException().CustomerFirstNameInvalid; }
        }
    }
}
