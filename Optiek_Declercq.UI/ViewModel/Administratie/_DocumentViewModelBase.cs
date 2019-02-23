using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Optiek_Declercq.Model.Contracts;

namespace Optiek_Declercq.UI.ViewModel.Administratie
{
    abstract class _DocumentViewModelBase :
        ViewModelBase, 
        IAdministration,
        IPrintable
    {
        public _DocumentViewModelBase()
        {

        }
    }
}
