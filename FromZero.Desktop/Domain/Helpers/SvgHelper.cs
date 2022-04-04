using SharpVectors.Converters;
using SharpVectors.Runtime;
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
