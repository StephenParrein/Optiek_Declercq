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
        public ICommand SaveChanges { get; set; }
        public ICommand CancelChanges { get; set; }

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
            set { _EditCustomer = value; RaisePropertyChanged("EditCustomer"); }
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

        private string _StatusLabel;
        public string StatusLabel
        {
            get
            {
                return _StatusLabel;
            }
            set
            {
                if (_StatusLabel == value)
                    return;
                _StatusLabel = value;
                RaisePropertyChanged("StatusLabel");
            }
        }

        private string _ErrorLabel;
        public string ErrorLabel
        {
            get
            {
                return _ErrorLabel;
            }
            set
            {
                if (_ErrorLabel == value)
                    return;
                _ErrorLabel = value;
                RaisePropertyChanged("ErrorLabel");
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
            SaveChanges = new RelayCommand(ExecuteSaveChanges);
            CancelChanges = new RelayCommand(ExecuteCancelChanges);

            customerService = new CustomerService();
            ListCustomers = customerService.All();

            StatusLabel = ListCustomers.Count + " klanten geladen.";
            ResetError();
        }

        private void ResetError()
        {
            ErrorLabel = "";
        }

        private void ExecuteAddCommand()
        {
            if (!BoolShowEditPartial) {
                ResetError();
                BoolShowEditPartial = true;
                EditCustomer = new Customer();
            }
            else
            {
                //TODO Error message save or cancel current edit operation
                ErrorLabel = "U bent nog een klant aan het editeren, gelieve eerst op te slaan of te annuleren.";
            }
        }

        private void ExecuteSaveChanges()
        {
            if (EditCustomer.ID == 0)
            {

            }
            else
            {

            }
        }

        private void ExecuteCancelChanges()
        {
            ResetError();
            string prompt = "";

            if (EditCustomer.ID == 0)
            {
                prompt = "Wenst u het toevoegen van een nieuwe klant te annuleren?";
            }
            else
            {
                prompt = "Wenst u het bewerken van een bestaande klant te annuleren?";
            }

            if (MessageBox.Show(prompt,
                     "Annuleren", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                EditCustomer = null;
                BoolShowEditPartial = false;
            }
        }

        private void ExecuteEditCommand()
        {
            if (SelectedCustomer != null &! BoolShowEditPartial)
            {
                ResetError();
                BoolShowEditPartial = true;
                EditCustomer = SelectedCustomer;
            }
            else if (BoolShowEditPartial)
            {
                //TODO Error message save or cancel current edit operation
                ErrorLabel = "U bent nog een klant aan het editeren, gelieve eerst op te slaan of te annuleren.";
            }
            else
            {
                BoolShowEditPartial = false;
                //TODO Error message select customer first
                ErrorLabel = "Gelieve eerst een klant te selecteren om te bewerken.";
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