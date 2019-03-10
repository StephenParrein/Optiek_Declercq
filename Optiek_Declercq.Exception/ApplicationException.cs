using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Exceptions
{
    public class ApplicationException : Exception
    {
        //Customer Exceptions
        public Exception CustomerFirstNameEmpty { get { return new Exception(ExDictionary.CustomerFirstNameEmpty); } }
        public Exception CustomerFirstNameInvalid { get { return new Exception(ExDictionary.CustomerFirstNameInvalid); } }
        public Exception CustomerFirstNameNull { get { return new Exception(ExDictionary.CustomerFirstNameNull); } }
        public Exception CustomerFirstNameToLong { get { return new Exception(ExDictionary.CustomerFirstNameToLong); } }
        public Exception CustomerFirstNameToShort { get { return new Exception(ExDictionary.CustomerFirstNameToShort); } }
        public Exception CustomerLastNameEmpty { get { return new Exception(ExDictionary.CustomerLastNameEmpty); } }
        public Exception CustomerLastNameInvalid { get { return new Exception(ExDictionary.CustomerLastNameInvalid); } }
        public Exception CustomerLastNameNull { get { return new Exception(ExDictionary.CustomerLastNameNull); } }
        public Exception CustomerLastNameToLong { get { return new Exception(ExDictionary.CustomerLastNameToLong); } }
        public Exception CustomerLastNameToShort { get { return new Exception(ExDictionary.CustomerLastNameToShort); } }

        //Global
        public Exception NotSavedException() => new Exception(ExDictionary.NotSaved);
        public Exception DatabaseConnectionError() => new Exception(ExDictionary.DatabaseConnectionError);
    }
}

