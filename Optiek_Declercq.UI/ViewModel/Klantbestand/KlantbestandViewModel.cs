using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Optiek_Declercq.Model.Models;
using Optiek_Declercq.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Optiek_Declercq.UI.ViewModel.Klantbestand
{
    class KlantbestandViewModel : ViewModelBase
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private readonly CustomerService customerService;
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

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set { _SelectedCustomer = value; RaisePropertyChanged(nameof(_SelectedCustomer)); }
        }

        private Customer _EditCustomer;
        public Customer EditCustomer
        {
            get => _EditCustomer;
            set { _EditCustomer = value; RaisePropertyChanged(nameof(_EditCustomer)); }
        }

        private bool _BoolShowEditPartial;
        public bool BoolShowEditPartial
        {
            get
            {
                return _BoolShowEditPartial;
            }
            set
            {
                if (_BoolShowEditPartial == value)
                    return;
                _BoolShowEditPartial = value;
                RaisePropertyChanged("EditPartialVisible");
            }
        }

        public Visibility EditPartialVisible
        {
            get { return BoolShowEditPartial ? Visibility.Visible : Visibility.Collapsed; }
        }

        public KlantbestandViewModel()
        {
            AddCommand = new RelayCommand(ExecuteAddCommand);
            EditCommand = new RelayCommand(ExecuteEditCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);

            customerService = new CustomerService();
            ListCustomers = customerService.All();
        }

        private void ExecuteAddCommand()
        {
            if (!BoolShowEditPartial) { 
                BoolShowEditPartial = true;
                EditCustomer = new Customer();
            }
            else
            {
                //TODO Error message save or cancel current edit operation
            }
        }

        private void ExecuteEditCommand()
        {
            if (SelectedCustomer != null &! BoolShowEditPartial)
            {
                BoolShowEditPartial = true;
                EditCustomer = SelectedCustomer;
            }
            else if (BoolShowEditPartial)
            {
                //TODO Error message save or cancel current edit operation
            }
            else
            {
                BoolShowEditPartial = false;
                //TODO Error message select customer first
            }
        }

        private void ExecuteDeleteCommand()
        {
            if (SelectedCustomer != null)
            {
                if (MessageBox.Show("Wenst u de klant " + SelectedCustomer.FirstName + " " + SelectedCustomer.Name + " te verwijderen?",
                     "Klant verwijderen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    SelectedCustomer = SelectedCustomer;
                    //Todo add service to remove the customer(set customer to inactive)
            }
        }
    }
}