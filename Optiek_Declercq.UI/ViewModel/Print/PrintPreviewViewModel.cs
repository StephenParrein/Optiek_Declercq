using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Optiek_Declercq.UI.ViewModel.Print
{
    class PrintPreviewViewModel : ViewModelBase
    {
        public RelayCommand PrintCommand
        {
            set
            {
                RelayCommand<FlowDocument> printCommand =
                    new RelayCommand<FlowDocument>(e => ExecutePrintCommand(e));
            }
        }

        public void ExecutePrintCommand(FlowDocument document)
        {
            PrintDocument(document);
        }

        private void PrintDocument(FlowDocument document)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                IDocumentPaginatorSource idpSource = document;
                // Call PrintDocument method to send document to printer
                print.PrintDocument(idpSource.DocumentPaginator, "Receipt Printing.");
            }
        }
    }
}
