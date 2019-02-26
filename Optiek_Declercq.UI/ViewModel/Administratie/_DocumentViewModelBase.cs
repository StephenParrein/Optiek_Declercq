using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using Optiek_Declercq.Model.Contracts;

namespace Optiek_Declercq.UI.ViewModel.Administratie
{
    abstract class _DocumentViewModelBase :
        ViewModelBase, 
        IAdministration,
        IPrintable
    {
        private bool _BoolShowEditPartial;
        public bool BoolShowEditPartial {
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

        public _DocumentViewModelBase()
        {
            BoolShowEditPartial = false;
        }
    }
}
