using FromZero.Desktop.Domain.Constants;
using FromZero.Desktop.Domain.Helpers;
using FromZero.Desktop.Domain.Models;
using FromZero.Desktop.Domain.ViewModels;
using SharpVectors.Converters;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace FromZero.Desktop.Domain.Views
{
    /// <summary>
    /// Interaction logic for MosaicMenu.xaml
    /// </summary>
    public partial class MosaicMenu : UserControl
    {
        private MosaicMenuViewModel _viewModel;

        #region Window

        public MosaicMenu()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
            Unloaded += WindowUnloaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MosaicMenuViewModel;

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
            _viewModel.MosaicItems = new(MosaicDefault.Items);

            _viewModel.MosaicItems.BuildPositions(columns: 6);
            _viewModel.MosaicItems.AdjustTitles(maxlength: 20);

            itemsControl.ItemsSource = _viewModel.MosaicItems;

            Dispatcher.BeginInvoke(SetTheme, DispatcherPriority.Render);
        }

        #endregion

        #region Functionality

        private void LoadUserControls(MosaicItem item)
        {
            if (IsMosaicItemEnable(item))
            {
                switch (item?.Target)
                {
                    case MosaicDefault.MosaicTargets.Attendance:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Attendance();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Dispatch:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Dispatch();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Supervision:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Supervision();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Administration:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Administration();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.UrgentNote:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new UrgentNote();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Occurrences:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Occurrences();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Queries:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Queries();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.CEPOL:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new CEPOL();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.AppUserManagment:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new AppUserManagment();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.Reports:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new Reports();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.DecisonTree:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new DecisonTree();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.OccurrenceRegister:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new OccurrenceRegister();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.WebAIA:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new WebAIA();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.COPOM:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new COPOM();
                        }
                        break;
                    case MosaicDefault.MosaicTargets.ForceMap:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new ForceMap();
                        }
                        break;
                    default:
                        {
                            _viewModel.GlobalProperties.CurrentControl = new MosaicMenu();
                        }
                        break;
                }
            }

            _viewModel.GlobalProperties.CurrentControl.DataContext = new MasterViewModel(_viewModel);

            ContentControl parent = (ContentControl)this.Parent;
            parent.Content = _viewModel.GlobalProperties.CurrentControl;
            ((UserControl)parent.Content).SetTheme();
        }

        #endregion

        #region Theme

        public void SetTheme()
        {
            foreach (SvgViewbox img in this.FindVisualChilds<SvgViewbox>())
            {
                if (img.Tag != null && img.Tag.ToString().Equals(NamesDefault.MosaicButtonImagePrefix))
                {
                    img.ChangeFill(_viewModel.GlobalProperties.CurrentTheme.IconImageColor);
                }
            }

            foreach (Border bkg in this.FindVisualChilds<Border>())
            {
                if (bkg.Tag != null && bkg.Tag.ToString().Equals(NamesDefault.MosaicButtonBackgroundPrefix))
                {
                    bkg.Background = _viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor;
                }
            }

            foreach (TextBlock lbl in this.FindVisualChilds<TextBlock>())
            {
                if (lbl.Tag != null && lbl.Tag.ToString().Equals(NamesDefault.MosaicButtonLabelPrefix))
                {
                    lbl.Foreground = _viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor;
                }
            }

            MosaicFilter();
        }

        #endregion

        #region Mosaic

        public bool IsMosaicItemEnable(MosaicItem item)
        {
            return item.IsFiltered && item.IsUserEnabled && (_viewModel.GlobalProperties.IsOnline ? true : item.IsOfflineEnabled);
        }

        public void MosaicFilter()
        {
            foreach (MosaicItem item in _viewModel?.MosaicItems)
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

        public void MosaicDisable(MosaicItem item, bool isEnabled)
        {
            SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).FirstOrDefault();
            if (img != null)
            {
                img.ChangeFill(isEnabled ? _viewModel.GlobalProperties.CurrentTheme.IconImageColor : _viewModel.GlobalProperties.CurrentTheme.IconImageDisabledColor);
                //img.Visibility = isEnabled ? Visibility.Visible : Visibility.Collapsed;
            }

            Border bkg = this.FindVisualChilds<Border>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagBackground).FirstOrDefault();
            if (bkg != null)
            {
                bkg.Background = isEnabled ? _viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor : _viewModel.GlobalProperties.CurrentTheme.IconBackgroundDisabledColor;
                //bkg.Visibility = isEnabled ? Visibility.Visible : Visibility.Collapsed;
            }

            foreach (TextBlock lbl in this.FindVisualChilds<TextBlock>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagLabel))
            {
                lbl.Foreground = isEnabled ? _viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor : _viewModel.GlobalProperties.CurrentTheme.IconBackgroundDisabledColor;
                //lbl.Visibility = isEnabled ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public void MosaicHighlight(MosaicItem item, bool isOn)
        {
            if (IsMosaicItemEnable(item))
            {
                SvgViewbox img = this.FindVisualChilds<SvgViewbox>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagImage).First();
                img.ChangeFill(isOn ? _viewModel.GlobalProperties.CurrentTheme.IconImageHighlightColor : _viewModel.GlobalProperties.CurrentTheme.IconImageColor);

                Border bkg = this.FindVisualChilds<Border>().Where(x => x.Tag != null && x.Tag.ToString() == item.TagBackground).First();
                bkg.Background = isOn ? _viewModel.GlobalProperties.CurrentTheme.IconBackgroundHighlightColor : _viewModel.GlobalProperties.CurrentTheme.IconBackgroundColor;
            }
        }


        //Events


        private void MosaicFilterTrigger(object sender, KeyEventArgs e)
        {
            MosaicFilter();
        }

        protected void MosaicItemClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MosaicItem item = _viewModel.MosaicItems.Where(x => x.TagButton == button.Tag.ToString()).First();

            LoadUserControls(item);
        }

        protected void MosaicHighlightOnTrigger(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MosaicItem item = _viewModel.MosaicItems.Where(x => x.TagButton == button.Tag.ToString()).First();

            MosaicHighlight(item, true);
        }

        protected void MosaicHighlightOffTrigger(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MosaicItem item = _viewModel.MosaicItems.Where(x => x.TagButton == button.Tag.ToString()).First();

            MosaicHighlight(item, false);
        }

        #endregion
    }
}
