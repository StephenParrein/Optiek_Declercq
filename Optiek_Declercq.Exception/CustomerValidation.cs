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
        internal void CheckCustomerModel(Customer customer)
        {
            //Validation for the customer last name
            if (customer.Name == null) { throw new ApplicationException().CustomerLastNameNull; }

            string customerName = customer.Name.Trim();

            if (customerName.Equals("")) { throw new ApplicationException().CustomerLastNameEmpty; }
            if (customerName.Length < 2) { throw new ApplicationException().CustomerLastNameToShort; }
            if (customerName.Length > 100) { throw new ApplicationException().CustomerLastNameToLong; }
            if (Regex.IsMatch(customerName, @"^[A-Za-z0-9_']+\s?,\s?[A-Za-z0-9_']+"))
            { throw new ApplicationException().CustomerLastNameInvalid; }


        }
    }
}
