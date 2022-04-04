using FromZero.Desktop.Domain.Models;
using System.Collections.ObjectModel;

namespace FromZero.Desktop.Domain.ViewModels
{
    public class MosaicMenuViewModel : MasterViewModel
    {
        public ObservableCollection<MosaicItem> MosaicItems { get; set; }

        public MosaicMenuViewModel(MasterViewModel masterView)
        {
            GlobalProperties = masterView.GlobalProperties;

            MosaicItems = new();
        }
    }
}
