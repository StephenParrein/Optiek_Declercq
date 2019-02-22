using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Optiek_Declercq.UI.ViewModel.Administratie;
using Optiek_Declercq.UI.ViewModel.Help;
using Optiek_Declercq.UI.ViewModel.Klantbestand;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Optiek_Declercq.UI.ViewModel
{
    /// <summary>
    /// The MainViewModel targets navigation within the application.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //Properties
        private ViewModelBase _LastViewModelState;
        public ViewModelBase LastViewModelState
        {
            get
            {
                return _LastViewModelState;
            }
            set
            {
                if (_LastViewModelState == value)
                    return;
                _LastViewModelState = value;
                RaisePropertyChanged("LastViewModel");
            }
        }

        private ViewModelBase _CurrentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }
            set
            {
                if (_CurrentViewModel == value)
                    return;
                _CurrentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        /// <summary>
        /// Navigation link between ViewModel and View can be found in App.xaml
        /// </summary>
        //Administratie
        public ICommand NavNewInvoiceCommand { get; set; }
        public ICommand NavEditInvoiceCommand { get; set; }
        public ICommand SaveInvoiceCommand { get; set; }

        //Klantbestand
        public ICommand NavClientsCommand { get; set; }

        //Beheer
        public ICommand NavInvoiceDeliveryCommand { get; set; }
        public ICommand NavInvoiceCommand { get; set; }
        public ICommand NavInvoiceAllCommand { get; set; }

        //Help
        public ICommand NavInfoCommand { get; set; }

        public MainViewModel()
        {
            NavNewInvoiceCommand = new RelayCommand(ExecNavNewInvoiceCommand);
            NavEditInvoiceCommand = new RelayCommand(ExecNavEditInvoiceCommand);
            SaveInvoiceCommand = new RelayCommand(ExecSaveInvoiceCommand);
            NavInvoiceDeliveryCommand = new RelayCommand(ExecNavInvoiceDeliveryCommand);
            NavInvoiceCommand = new RelayCommand(ExecNavInvoiceCommand);
            NavInvoiceAllCommand = new RelayCommand(ExecNavInvoiceAllCommand);
            NavInfoCommand = new RelayCommand(ExecNavInfoCommand);

        }

        private void ExecNavNewInvoiceCommand()
        {
            NavigateToPage(new NewInvoiceViewModel());
        }

        private void ExecNavEditInvoiceCommand()
        {
            NavigateToPage(new EditInvoiceViewModel());
        }

        private void ExecSaveInvoiceCommand()
        {
            //TODO model binding command active when editing invoice
            //TODO save model state while editing if changes have been made
        }

        private void ExecNavClientsCommand()
        {
            NavigateToPage(new KlantbestandViewModel());
        }

        private void ExecNavInvoiceDeliveryCommand()
        {
            //CurrentViewModel = new NewInvoiceViewModel();
        }

        private void ExecNavInvoiceCommand()
        {
            //CurrentViewModel = new NewInvoiceViewModel();
        }

        private void ExecNavInvoiceAllCommand()
        {
            //CurrentViewModel = new NewInvoiceViewModel();
        }

        private void ExecNavInfoCommand()
        {
            NavigateToPage(new InfoViewModel());
        }

        private void NavigateToPage(ViewModelBase viewModel)
        {
            try { 
                LastViewModelState = CurrentViewModel;
                CurrentViewModel = viewModel;
            }catch(Exception e)
            {
                //Todo redirect user to help page. Unable to load page.

                //Temp: Write error to console
                Console.Write(e.StackTrace);
            }
        }

    }
}