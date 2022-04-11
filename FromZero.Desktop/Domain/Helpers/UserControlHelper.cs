using FromZero.Desktop.Domain.Constants;
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

            userControl.SetThemeCommons();

            if (m != null)
            {
                m.Invoke(userControl, null);
            }
        }

        private static void SetThemeCommons(this UserControl userControl)
        {
            MasterViewModel viewModel = userControl.DataContext as MasterViewModel;

            foreach (Label lbl in userControl.FindVisualChilds<Label>())
            {
                if (lbl.Tag != null && lbl.Tag.ToString().Equals(NamesDefault.ThemeTag))
                {
                    lbl.Foreground = viewModel.GlobalProperties.CurrentTheme.FontColor;
                }
            }

            foreach (Button btn in userControl.FindVisualChilds<Button>())
            {
                if (btn.Tag != null && btn.Tag.ToString().Equals(NamesDefault.ThemeTag))
                {
                    btn.Background = viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor;
                    btn.Foreground = viewModel.GlobalProperties.CurrentTheme.IconImageColor;
                }
            }
        }

        public static void BackToMosaicMenu(this UserControl userControl)
        {
            MasterViewModel viewModel = userControl.DataContext as MasterViewModel;

            viewModel.GlobalProperties.CurrentControl = new MosaicMenu();
            viewModel.GlobalProperties.CurrentControl.DataContext = new MosaicMenuViewModel(viewModel);

            ContentControl parent = (ContentControl)userControl.Parent;
            parent.Content = viewModel.GlobalProperties.CurrentControl;
        }
    }
}
