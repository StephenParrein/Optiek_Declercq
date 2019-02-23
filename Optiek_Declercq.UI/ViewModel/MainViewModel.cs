using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Optiek_Declercq.Model.Contracts;
using Optiek_Declercq.UI.ViewModel.Administratie;
using Optiek_Declercq.UI.ViewModel.Help;
using Optiek_Declercq.UI.ViewModel.Klantbestand;
using Optiek_Declercq.UI.ViewModel.Print;
using Optiek_Declercq.UI.ViewModel.Shared;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Optiek_Declercq.UI.ViewModel
{

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

        /// <Properties>
        /// Global interface settings
        /// </Properties>
        //UI properties
        private bool _PropertyPrintingEnabled;
        public bool PropertyPrintingEnabled
        {
            get
            {
                return _PropertyPrintingEnabled;
            }
            set
            {
                if (_PropertyPrintingEnabled == value)
                    return;
                _PropertyPrintingEnabled = value;
                RaisePropertyChanged("PropertyPrintingEnabled");
            }
        }

        private bool _PropertyPrintPreviewEnabled;
        public bool PropertyPrintPreviewEnabled
        {
            get
            {
                return _PropertyPrintPreviewEnabled;
            }
            set
            {
                if (_PropertyPrintPreviewEnabled == value)
                    return;
                _PropertyPrintPreviewEnabled = value;
                RaisePropertyChanged("PropertyPrintPreviewEnabled");
            }
        }

        private bool _DocumentNewSaveState; //Prompt user a message when document is not saved
        public bool DocumentNewSaveState
        {
            get
            {
                return _DocumentNewSaveState;
            }
            set
            {
                if (_DocumentNewSaveState == value)
                    return;
                _DocumentNewSaveState = value;
                RaisePropertyChanged("PropertyPrintPreviewEnabled");
            }
        }

        /// <CommandSummary>
        /// Navigation link between ViewModel and View can be found in App.xaml
        /// </CommandSummary>
        //Administratie
        public ICommand NavNewInvoiceCommand { get; set; }
        public ICommand NavEditInvoiceCommand { get; set; }
        public ICommand SaveInvoiceCommand { get; set; }

        //Print
        public ICommand NavPrintCommand { get; set; }
        public ICommand NavPrintPreviewCommand { get; set; }

        //Klantbestand
        public ICommand NavClientsCommand { get; set; }

        //Beheer
        public ICommand NavDeliveryOverviewCommand { get; set; }
        public ICommand NavInvoiceOverviewCommand { get; set; }
        public ICommand NavQuotationOverviewCommand { get; set; }
        public ICommand NavGlobalOverviewCommand { get; set; }

        //Global
        public ICommand NavDashboardCommand { get; set; }

        //Help
        public ICommand NavInfoCommand { get; set; }

        public MainViewModel()
        {
            NavNewInvoiceCommand = new RelayCommand(ExecNavNewInvoiceCommand);
            NavEditInvoiceCommand = new RelayCommand(ExecNavEditInvoiceCommand);
            SaveInvoiceCommand = new RelayCommand(ExecSaveInvoiceCommand);

            NavDeliveryOverviewCommand = new RelayCommand(ExecNavInvoiceDeliveryCommand);
            NavClientsCommand = new RelayCommand(ExecNavClientsCommand);
            NavInvoiceOverviewCommand = new RelayCommand(ExecNavInvoiceCommand);
            NavGlobalOverviewCommand = new RelayCommand(ExecNavInvoiceAllCommand);
            NavInfoCommand = new RelayCommand(ExecNavInfoCommand);

            NavPrintCommand = new RelayCommand(ExecNavPrintCommand);
            NavPrintPreviewCommand = new RelayCommand(ExecNavPrintPreviewCommand);

            NavDashboardCommand = new RelayCommand(ExecNavDashboardCommand);

            ExecNavDashboardCommand();

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

        private void ExecNavPrintCommand()
        {
            NavigateToPage(new PrintViewModel());
        }

        private void ExecNavPrintPreviewCommand()
        {
            NavigateToPage(new PrintPreviewViewModel());
        }

        private void ExecNavDashboardCommand()
        {
            NavigateToPage(new DashBoardViewModel());
        }

        private void NavigateToPage(ViewModelBase viewModel)
        {
            try {
                Type type = viewModel.GetType();

                if(type.BaseType.Name.Equals("_DocumentViewModelBase"))
                {
                    PropertyPrintingEnabled = true;
                    PropertyPrintPreviewEnabled = true;
                }
                else
                {
                    PropertyPrintingEnabled = false;
                    PropertyPrintPreviewEnabled = false;
                }

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