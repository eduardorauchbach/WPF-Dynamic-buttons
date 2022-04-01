using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Helpers
{
    public static class ControlHelper
    {
        public static void Toggle(this ItemsControl sender)
        {
            sender.Visibility = sender.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        public static void Toggle(this Grid sender)
        {
            sender.Visibility = sender.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        public static void Toggle(this Image sender)
        {
            sender.Visibility = sender.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        public static void Toggle(this Button sender)
        {
            sender.Visibility = sender.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }

        public static IEnumerable<T> FindVisualChilds<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChilds<T>(ithChild)) yield return childOfChild;
            }
        }
    }
}
