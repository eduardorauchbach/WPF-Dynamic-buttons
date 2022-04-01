using FromZero.Desktop.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Models
{
    public class Theme
    {
        public ThemeType ActiveTheme { get; set; }

        public Brush BackgroundColor { get; private set; }
        public Brush FontColor { get; private set; }

        public Brush? IconBackgroundColor { get; private set; }
        public Brush? IconImageColor { get; private set; }

        public Brush? IconBackgroundHighlightColor { get; private set; }
        public Brush? IconImageHighlightColor { get; private set; }

        public Brush? IconBackgroundDisabledColor { get; private set; }
        public Brush? IconImageDisabledColor { get; private set; }

        public Theme(ThemeType type)
        {
            SetTheme(type);
        }

        public void SetTheme(ThemeType type)
        {
            ActiveTheme = type;

            switch (type)
            {
                case ThemeType.White:
                    {
                        BackgroundColor = ThemeConfigurations.White.BackgroundColor;
                        FontColor = ThemeConfigurations.White.FontColor;

                        IconBackgroundColor = ThemeConfigurations.White.IconBackgroundColor;
                        IconImageColor = ThemeConfigurations.White.IconImageColor;

                        IconBackgroundHighlightColor = ThemeConfigurations.White.IconBackgroundHighlightColor;
                        IconImageHighlightColor = ThemeConfigurations.White.IconImageHighlightColor;

                        IconBackgroundDisabledColor = ThemeConfigurations.White.IconBackgroundDisabledColor;
                        IconImageDisabledColor = ThemeConfigurations.White.IconImageDisabledColor;
                    }
                    break;
                case ThemeType.Black:
                    {
                        {
                            BackgroundColor = ThemeConfigurations.Black.BackgroundColor;
                            FontColor = ThemeConfigurations.Black.FontColor;

                            IconBackgroundColor = ThemeConfigurations.Black.IconBackgroundColor;
                            IconImageColor = ThemeConfigurations.Black.IconImageColor;

                            IconBackgroundHighlightColor = ThemeConfigurations.Black.IconBackgroundHighlightColor;
                            IconImageHighlightColor = ThemeConfigurations.Black.IconImageHighlightColor;

                            IconBackgroundDisabledColor = ThemeConfigurations.Black.IconBackgroundDisabledColor;
                            IconImageDisabledColor = ThemeConfigurations.Black.IconImageDisabledColor;
                        }
                    }
                    break;
            }
        }

        private static class ThemeConfigurations
        {
            public static class White
            {
                public static Brush BackgroundColor = new SolidColorBrush(Colors.LightGray);
                public static Brush FontColor = "#242424".ToBrush();

                public static Brush IconBackgroundColor = "#242424".ToBrush();
                public static Brush IconImageColor = new SolidColorBrush(Colors.LightGray);

                public static Brush IconBackgroundHighlightColor = "#242424".ToBrush();
                public static Brush IconImageHighlightColor = new SolidColorBrush(Colors.White);

                public static Brush IconBackgroundDisabledColor = new SolidColorBrush(Colors.Gray);
                public static Brush IconImageDisabledColor = new SolidColorBrush(Colors.LightGray);
            }

            public static class Black
            {
                public static Brush BackgroundColor = "#242424".ToBrush();
                public static Brush FontColor = new SolidColorBrush(Colors.LightGray);

                public static Brush IconBackgroundColor = new SolidColorBrush(Colors.LightGray);
                public static Brush IconImageColor = "#242424".ToBrush();

                public static Brush IconBackgroundHighlightColor = new SolidColorBrush(Colors.LightGray);
                public static Brush IconImageHighlightColor = new SolidColorBrush(Colors.DarkGray);

                public static Brush IconBackgroundDisabledColor = new SolidColorBrush(Colors.Gray);
                public static Brush IconImageDisabledColor = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }

    public enum ThemeType
    {
        White,
        Black,
    }
}
