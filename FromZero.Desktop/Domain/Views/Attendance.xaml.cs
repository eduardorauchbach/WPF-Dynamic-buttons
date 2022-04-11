using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FromZero.Desktop.Domain.Views
{
    /// <summary>
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : UserControl
    {
        private AttendanceViewModel _viewModel;

        #region Window

        public Attendance()
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
            //txtDemo.Text = this.GetType().Name;

            //ChangeTheme();
        }

        #endregion

        #region  Functionality

        private void Commit()
        {
            bool ok = true;

            if (!drpCopom.IsRequiredValidation())
            {
                ok = false;
            }

            if (!drpServico.IsRequiredValidation())
            {
                ok = false;
            }

            if (!drpPosicaoAtendimento.IsRequiredValidation())
            {
                ok = false;
            }

            if (ok)
            {
                //Faça sua magina
            }
        }

        private void Commit(object sender, RoutedEventArgs e)
        {
            Commit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.BackToMosaicMenu();
        }

        #endregion
    }
}
