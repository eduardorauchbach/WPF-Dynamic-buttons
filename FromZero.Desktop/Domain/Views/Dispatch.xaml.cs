using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FromZero.Desktop.Domain.Views
{
    /// <summary>
    /// Interaction logic for Dispatch.xaml
    /// </summary>
    public partial class Dispatch : UserControl
    {
        private DispatchViewModel _viewModel;

        #region Window

        public Dispatch()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
            Unloaded += WindowUnloaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new((MasterViewModel)DataContext);
            DataContext = _viewModel;

            Load();
        }

        private void WindowUnloaded(object sender, RoutedEventArgs e)
        {
            //Dispose
        }

        #endregion

        #region Load

        public void Load()
        {
            txtDemo.Text = this.GetType().Name;

            //ChangeTheme();
        }

        #endregion

        #region  Functionality

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.BackToMosaicMenu();
        }

        #endregion
    }
}
