using FromZero.Desktop.Domain.Helpers;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Models
{
    public class Theme
    {
        public ThemeType ActiveTheme { get; set; }

        public Brush BackgroundColor { get; private set; }
        public Brush FontColor { get; private set; }

        public Brush IconBackgroundColor { get; private set; }
        public Brush IconImageColor { get; private set; }

        public Brush IconBackgroundHighlightColor { get; private set; }
        public Brush IconImageHighlightColor { get; private set; }

        public Brush IconBackgroundDisabledColor { get; private set; }
        public Brush IconImageDisabledColor { get; private set; }

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
                public static Brush BackgroundColor = "#E9E9E9".ToBrush();
                public static Brush FontColor = "#343434".ToBrush();

                public static Brush IconBackgroundColor = "#343434".ToBrush();
                public static Brush IconImageColor = "#E9E9E9".ToBrush();

                public static Brush IconBackgroundHighlightColor = "#000000".ToBrush();
                public static Brush IconImageHighlightColor = "#ffffff".ToBrush();

                public static Brush IconBackgroundDisabledColor = new SolidColorBrush(Colors.Gray);
                public static Brush IconImageDisabledColor = new SolidColorBrush(Colors.LightGray);
            }

            public static class Black
            {
                public static Brush BackgroundColor = "#343434".ToBrush();
                public static Brush FontColor = "#E9E9E9".ToBrush();

                public static Brush IconBackgroundColor = "#E9E9E9".ToBrush();
                public static Brush IconImageColor = "#343434".ToBrush();

                public static Brush IconBackgroundHighlightColor = "#ffffff".ToBrush();
                public static Brush IconImageHighlightColor = "#000000".ToBrush();

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
