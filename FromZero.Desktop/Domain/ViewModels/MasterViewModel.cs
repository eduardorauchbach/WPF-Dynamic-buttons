using FromZero.Desktop.Domain.Models;
using System.Windows.Controls;

namespace FromZero.Desktop.Domain.ViewModels
{
    public class MasterViewModel
    {
        public MasterViewModel()
        {
            GlobalProperties = new();
        }

        public MasterViewModel(MasterViewModel masterView)
        {
            GlobalProperties = masterView.GlobalProperties;
        }

        public Properties GlobalProperties { get; set; }

        public class Properties
        {
            public UserControl CurrentControl { get; set; }

            public bool IsOnline { get; set; }
            public Theme CurrentTheme { get; set; }
            public User CurrentUser { get; set; }
        }
    }
}
