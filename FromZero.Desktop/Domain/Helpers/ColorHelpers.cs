using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Helpers
{
    public static class ColorHelpers
    {
        public static SolidColorBrush ToBrush(this string hexColorString)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColorString));
        }

        public static Color ToColor(this string hexColorString)
        {
            return (Color)ColorConverter.ConvertFromString(hexColorString);
        }
    }
}
