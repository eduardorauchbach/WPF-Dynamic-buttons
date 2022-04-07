using SharpVectors.Converters;
using SharpVectors.Runtime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Helpers
{
    public static class SvgHelper
    {
        public static void ChangeFill(this SvgViewbox viewbox, Brush brush)
        {
            var drawings = ((SvgDrawingCanvas)viewbox.Child).DrawObjects;

            foreach (var drawing in drawings)
            {
                if (drawing is GeometryDrawing geometryDrawing)
                {
                    geometryDrawing.Brush = brush;
                }
            }
        }

        public static void ChangeLine(this SvgViewbox viewbox, Brush brush)
        {
            var drawings = ((SvgDrawingCanvas)viewbox.Child).DrawObjects;

            foreach (var drawing in drawings)
            {
                if (drawing is GeometryDrawing geometryDrawing)
                {
                    // svg stroke color - translated to a geometry.Pen.Brush
                    if (geometryDrawing.Pen != null)
                    {
                        geometryDrawing.Pen.Brush = brush;
                    }
                }
            }
        }
    }

    public class SvgImage : Image
    {
        public string SvgSource
        {
            get => (string)GetValue(SvgSourceProperty);
            set => SetValue(SvgSourceProperty, value);
        }

        public static readonly DependencyProperty SvgSourceProperty = DependencyProperty
            .Register("SvgSource", typeof(string), typeof(SvgImage), new PropertyMetadata(string.Empty, OnSvgSourceChanged));

        private static void OnSvgSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SvgImage image)
            {
                var converter = new SvgImageConverterExtension
                {
                    AppName = "FromZero.Desktop"
                };
                var binding = new Binding
                {
                    Converter = converter,
                    ConverterParameter = e.NewValue
                };

                image.SetBinding(SourceProperty, binding);
            }
        }
    }
}
