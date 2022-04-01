using FromZero.Desktop.Domain.Helpers;
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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }

        private void UserMenuToggle(object sender, RoutedEventArgs e)
        {
            drpMenu.Toggle();
        }





        #region Buttons

        protected void ButtonHighLightOn(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace("btn", "img");
            
            SvgHelper svgHelper = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            svgHelper.Fill = new SolidColorBrush(Colors.White);
        }

        protected void ButtonHighLightOff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string imageName = button.Tag.ToString().Replace("btn", "img");

            SvgHelper svgHelper = this.FindVisualChilds<SvgHelper>().Where(x => x.Tag != null && x.Tag.ToString() == imageName).First();
            svgHelper.Fill = new SolidColorBrush(Colors.LightGray);
        }

        #endregion
    }
}
