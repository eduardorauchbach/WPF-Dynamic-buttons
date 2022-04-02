using FromZero.Desktop.Domain.Models;

namespace FromZero.Desktop.Domain.ViewModels
{
    public class MasterViewModel
    {
        public bool isOnline { get; set; }
        public Theme CurrentTheme { get; set; }
        public User CurrentUser { get; set; }
    }
}
