using GalaSoft.MvvmLight;
using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.UI.ViewModel.Klantbestand
{
    class KlantbestandViewModel : ViewModelBase
    {
        private IList<Customer> _ListCustomers { get; set; }
        public IList<Customer> ListCustomers
        {
            get
            {
                return _ListCustomers;    
            }
            set
            {
                if (value == _ListCustomers)
                {
                    return;
                }
                else
                {
                    _ListCustomers = value;
                    RaisePropertyChanged("ListCustomers");
                }
            }
        }

        public KlantbestandViewModel()
        {
            //ListCustomers = new CustomerService().All();
        }
    }
}