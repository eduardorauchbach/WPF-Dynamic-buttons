using SharpVectors.Converters;
using SharpVectors.Dom.Svg;
using SharpVectors.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
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
}
