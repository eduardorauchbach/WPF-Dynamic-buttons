using FromZero.Desktop.Domain.Constants;
using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.Models;
using FromZero.Desktop.Domain.ViewModels;
using SharpVectors.Converters;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        #region Window

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
            ContentRendered += MainWindowContentRendered;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            LoadUser();
            LoadDefault();
        }

        private void MainWindowContentRendered(object? sender, EventArgs e)
        {
            bodyMainWindow.Background = _viewModel.GlobalProperties.CurrentTheme.BackgroundColor;
        }

        #endregion

        #region Load

        private void LoadDefault()
        {
            _viewModel.GlobalProperties.CurrentControl = new MosaicMenu();
            _viewModel.GlobalProperties.CurrentControl.DataContext = new MosaicMenuViewModel(_viewModel);

            contentMainWindow.Content = _viewModel.GlobalProperties.CurrentControl;
        }

        private void LoadUser()
        {
            SetUserOnlineMode(true); //Fixo, diz se esta online ou não

            _viewModel.GlobalProperties.CurrentUser = new("Rauchbach", "000.000.000-00", "LUCK", "666");
            _viewModel.GlobalProperties.CurrentTheme = new(ThemeType.White);
        }

        #endregion

        #region UserControl

        private void UserMenuToggle(object sender, RoutedEventArgs e)
        {
            drpMenu.Toggle();
        }

        private void SetUserOnlineMode(bool isOnline)
        {
            _viewModel.GlobalProperties.IsOnline = isOnline;

            if (isOnline)
            {
                iconUserGlowBorder.Background = new SolidColorBrush(Colors.LawnGreen);
                iconUserGlowEffect.Color = Colors.LawnGreen;
            }
            else
            {
                iconUserGlowBorder.Background = new SolidColorBrush(Colors.OrangeRed);
                iconUserGlowEffect.Color = Colors.OrangeRed;
            }
        }

        #endregion

        #region Global Theme

        protected void ChangeTheme()
        {
            if (_viewModel.GlobalProperties.CurrentTheme.ActiveTheme == ThemeType.White)
            {
                _viewModel.GlobalProperties.CurrentTheme.SetTheme(ThemeType.Black);
                btnDayMode.Visibility = Visibility.Visible;
                btnNightMode.Visibility = Visibility.Collapsed;
            }
            else
            {
                _viewModel.GlobalProperties.CurrentTheme.SetTheme(ThemeType.White);
                btnDayMode.Visibility = Visibility.Collapsed;
                btnNightMode.Visibility = Visibility.Visible;
            }

            bodyMainWindow.Background = _viewModel.GlobalProperties.CurrentTheme.BackgroundColor;
            _viewModel.GlobalProperties.CurrentControl.SetTheme();
        }

        //Events
        protected void ChangeTheme(object sender, RoutedEventArgs e)
        {
            ChangeTheme();
        }

        #endregion

        #region Menu

        private void ToggleExitModal()
        {
            ModalExit.Visibility = ModalExit.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        protected void ButtonHighLightOn(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace(NamesDefault.ButtonPrefix, NamesDefault.ButtonImagePrefix);

            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.ChangeFill(new SolidColorBrush(Colors.White));
        }

        protected void ButtonHighLightOff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace(NamesDefault.ButtonPrefix, NamesDefault.ButtonImagePrefix);

            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.ChangeFill(new SolidColorBrush(Colors.LightGray));
        }

        protected void ToggleExitModal(object sender, RoutedEventArgs e)
        {
            ToggleExitModal();
        }
        protected void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
