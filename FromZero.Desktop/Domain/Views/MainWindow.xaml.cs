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

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;

            bodyMainWindow.Background = ViewModel.CurrentTheme.BackgroundColor;
            MosaicChangeTheme();
        }

        private void UserMenuToggle(object sender, RoutedEventArgs e)
        {
            drpMenu.Toggle();
        }

        #region Global Theme

        protected void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CurrentTheme.ActiveTheme == ThemeType.White)
            {
                ViewModel.CurrentTheme.SetTheme(ThemeType.Black);
                //Change button to day
            }
            else
            {
                ViewModel.CurrentTheme.SetTheme(ThemeType.White);
                //Change button to night
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

            SvgHelper img = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.Fill = new SolidColorBrush(Colors.White);
        }

        protected void ButtonHighLightOff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace(ButtonDefault.ButtonPrefix, ButtonDefault.ButtonImagePrefix);

            SvgHelper img = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            img.Fill = new SolidColorBrush(Colors.LightGray);
        }

        #endregion

        #region Mosaic

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

                MosaicDisable(item, item.IsFiltered && item.IsUserEnabled);
            }
        }

        private void MosaicChangeTheme()
        {
            foreach (SvgHelper img in this.FindVisualChilds<SvgHelper>())
            {
                if (img.Tag != null && img.Tag.ToString().Contains(ButtonDefault.MosaicButtonImagePrefix))
                {
                    img.Fill = ViewModel.CurrentTheme.IconImageColor;
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
            SvgHelper img = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).First();
            img.Fill = isEnabled ? ViewModel.CurrentTheme.IconImageColor : ViewModel.CurrentTheme.IconImageDisabledColor;

            Border bkg = this.FindVisualChilds<Border>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagBackground).First();
            bkg.Background = isEnabled ? ViewModel.CurrentTheme.IconBackgroundColor : ViewModel.CurrentTheme.IconBackgroundDisabledColor;

            foreach(TextBlock lbl in this.FindVisualChilds<TextBlock>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagLabel))
            {
                lbl.Foreground = isEnabled ? ViewModel.CurrentTheme.IconBackgroundColor : ViewModel.CurrentTheme.IconBackgroundDisabledColor;
            }            
        }

        private void MosaicHighlight(MosaicItem item, bool isOn)
        {
            if (item.IsFiltered && item.IsUserEnabled)
            {
                SvgHelper img = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).First();
                img.Fill = isOn ? ViewModel.CurrentTheme.IconImageHighlightColor : ViewModel.CurrentTheme.IconImageColor;

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
