using FromZero.Desktop.Domain.ViewModels;
using FromZero.Desktop.Domain.Views;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace FromZero.Desktop.Domain.Helpers
{
    public static class UserControlHelper
    {
        /// <summary>
        /// If the child User Control has a ChangeTheme Method, it will be Invoked
        /// </summary>
        /// <param name="userControl"></param>
        public static void SetTheme(this UserControl userControl)
        {
            MethodInfo? m = userControl.GetType().GetMethods().Where(x => x.Name == "SetTheme").FirstOrDefault();
            if (m != null)
            {
                m.Invoke(userControl, null);
            }
        }

        public static void BackToMosaicMenu(this UserControl userControl, MasterViewModel viewModel)
        {
            viewModel.GlobalProperties.CurrentControl = new MosaicMenu();
            viewModel.GlobalProperties.CurrentControl.DataContext = new MosaicMenuViewModel(viewModel);

            ContentControl parent = (ContentControl)userControl.Parent;
            parent.Content = viewModel.GlobalProperties.CurrentControl;
        }
    }
}
