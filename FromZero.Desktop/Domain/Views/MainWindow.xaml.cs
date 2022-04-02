using FromZero.Desktop.Domain.Constants;
using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.Models;
using FromZero.Desktop.Domain.ViewModels;
using SharpVectors.Converters;
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

namespace FromZero.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel;

        #region Window

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
            ContentRendered += MainWindowContentRendered;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;

            LoadUser();
            LoadMosaic();

            bodyMainWindow.Background = ViewModel.CurrentTheme.BackgroundColor;
        }

        private void MainWindowContentRendered(object? sender, EventArgs e)
        {
            MosaicFilter();
        }

        #endregion

        #region Load

        private void LoadMosaic()
        {
            ViewModel.MosaicItems = new(MosaicDefault.items);

            ViewModel.MosaicItems.BuildPositions(columns: 6);
            ViewModel.MosaicItems.AdjustTitles(maxlength: 20);

            MosaicChangeTheme();
        }

        private void LoadUser()
        {
            SetUserOnlineMode(false); //Fixo, diz se esta online ou não

            ViewModel.CurrentUser = new("SOUZA", "000.000.000-00", "1. TEN PM", "8.BPM/M");
            ViewModel.CurrentTheme = new(ThemeType.White);
        }

        #endregion

        #region UserControl

        private void UserMenuToggle(object sender, RoutedEventArgs e)
        {
            drpMenu.Toggle();
        }

        private void SetUserOnlineMode(bool isOnline)
        {
            ViewModel.isOnline = isOnline;

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

        protected void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentTheme.ActiveTheme == ThemeType.White)
            {
                ViewModel.CurrentTheme.SetTheme(ThemeType.Black);
                btnDayMode.Visibility = Visibility.Visible;
                btnNightMode.Visibility = Visibility.Collapsed;
            }
            else
            {
                ViewModel.CurrentTheme.SetTheme(ThemeType.White);
                btnDayMode.Visibility = Visibility.Collapsed;
                btnNightMode.Visibility = Visibility.Visible;
            }

            bodyMainWindow.Background = ViewModel.CurrentTheme.BackgroundColor;
            MosaicChangeTheme();
            MosaicFilter();
        }

        #endregion

        #region Menu

        protected void ButtonHighLightOn(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace(ButtonDefault.ButtonPrefix, ButtonDefault.ButtonImagePrefix);

            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.ChangeFill(new SolidColorBrush(Colors.White));
        }

        protected void ButtonHighLightOff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace(ButtonDefault.ButtonPrefix, ButtonDefault.ButtonImagePrefix);

            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.ChangeFill(new SolidColorBrush(Colors.LightGray));
        }

        #endregion

        #region Mosaic

        private bool IsMosaicItemEnable(MosaicItem item)
        {
            return item.IsFiltered && item.IsUserEnabled && (ViewModel.isOnline ? true : item.IsOfflineEnabled);
        }

        private void MosaicFilter()
        {
            foreach (MosaicItem item in ViewModel.MosaicItems)
            {
                if ((item.Title + item.Title2).ToUpper().Contains(txtMosaicFilter.Text.ToUpper()))
                {
                    item.IsFiltered = true;
                }
                else
                {
                    item.IsFiltered = false;
                }

                MosaicDisable(item, IsMosaicItemEnable(item));
            }
        }

        private void MosaicChangeTheme()
        {
            foreach (SvgViewbox img in this.FindVisualChilds<SvgViewbox>())
            {
                if (img.Tag != null && img.Tag.ToString().Contains(ButtonDefault.MosaicButtonImagePrefix))
                {
                    img.ChangeFill(ViewModel.CurrentTheme.IconImageColor);
                }
            }

            foreach (Border bkg in this.FindVisualChilds<Border>())
            {
                if (bkg.Tag != null && bkg.Tag.ToString().Contains(ButtonDefault.MosaicButtonBackgroundPrefix))
                {
                    bkg.Background = ViewModel.CurrentTheme.IconBackgroundColor;
                }
            }

            foreach (TextBlock lbl in this.FindVisualChilds<TextBlock>())
            {
                if (lbl.Tag != null && lbl.Tag.ToString().Contains(ButtonDefault.MosaicButtonLabelPrefix))
                {
                    lbl.Foreground = ViewModel.CurrentTheme.IconBackgroundColor;
                }
            }
        }

        private void MosaicDisable(MosaicItem item, bool isEnabled)
        {
            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).First();
            img.ChangeFill(isEnabled ? ViewModel.CurrentTheme.IconImageColor : ViewModel.CurrentTheme.IconImageDisabledColor);

            Border bkg = this.FindVisualChilds<Border>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagBackground).First();
            bkg.Background = isEnabled ? ViewModel.CurrentTheme.IconBackgroundColor : ViewModel.CurrentTheme.IconBackgroundDisabledColor;

            foreach (TextBlock lbl in this.FindVisualChilds<TextBlock>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagLabel))
            {
                lbl.Foreground = isEnabled ? ViewModel.CurrentTheme.IconBackgroundColor : ViewModel.CurrentTheme.IconBackgroundDisabledColor;
            }
        }

        private void MosaicHighlight(MosaicItem item, bool isOn)
        {
            if (IsMosaicItemEnable(item))
            {
                SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).First();
                img.ChangeFill(isOn ? ViewModel.CurrentTheme.IconImageHighlightColor : ViewModel.CurrentTheme.IconImageColor);

                Border bkg = this.FindVisualChilds<Border>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagBackground).First();
                bkg.Background = isOn ? ViewModel.CurrentTheme.IconBackgroundHighlightColor : ViewModel.CurrentTheme.IconBackgroundColor;
            }
        }


        //Events


        private void MosaicFilterTrigger(object sender, KeyEventArgs e)
        {
            MosaicFilter();
        }

        protected void MosaicHighlightOnTrigger(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MosaicItem item = ViewModel.MosaicItems.Where(x => x.TagButton == button.Tag.ToString()).First();

            MosaicHighlight(item, true);
        }

        protected void MosaicHighlightOffTrigger(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MosaicItem item = ViewModel.MosaicItems.Where(x => x.TagButton == button.Tag.ToString()).First();

            MosaicHighlight(item, false);
        }

        #endregion
    }
}
