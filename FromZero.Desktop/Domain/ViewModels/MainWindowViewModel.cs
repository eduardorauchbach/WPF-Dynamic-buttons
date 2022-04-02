using FromZero.Desktop.Domain.Constants;
using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromZero.Desktop.Domain.ViewModels
{
    public class MainWindowViewModel : MasterViewModel
    {
        public ObservableCollection<MosaicItem> MosaicItems { get; set; }

        public MainWindowViewModel()
        {
            MosaicItems = new ();            
        }
    }
}
