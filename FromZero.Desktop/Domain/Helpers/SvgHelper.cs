using SharpVectors.Converters;
using SharpVectors.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FromZero.Desktop.Domain.Helpers
{
    internal class SvgHelper : SvgViewbox
    {
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(SvgHelper), new PropertyMetadata(Brushes.LightGray));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("Stroke", typeof(Brush), typeof(SvgHelper), new PropertyMetadata(Brushes.LightGray));

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public Brush Stroke
        {
            get => (Brush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        protected override void OnSettingsChanged()
        {
            base.OnSettingsChanged();

            var drawings = ((SvgDrawingCanvas)Child).DrawObjects;

            foreach (var drawing in drawings)
            {
                if (drawing is GeometryDrawing geometryDrawing)
                {
                    // svg fill color - translated to a geometry.Brush
                    var brush = new Binding(nameof(Fill))
                    {
                        Source = this,
                        Mode = BindingMode.OneWay
                    };
                    BindingOperations.SetBinding(geometryDrawing, GeometryDrawing.BrushProperty, brush);

                    // svg stroke color - translated to a geometry.Pen.Brush
                    if (geometryDrawing.Pen != null)
                    {
                        var stroke = new Binding(nameof(Stroke))
                        {
                            Source = this,
                            Mode = BindingMode.OneWay
                        };
                        BindingOperations.SetBinding(geometryDrawing.Pen, Pen.BrushProperty, stroke);
                    }
                }
            }
        }

    }
}
