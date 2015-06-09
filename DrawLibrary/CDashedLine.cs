using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawLibrary
{
    public class CDashedLine: CLine
    {
        public CDashedLine(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _lineObject = new Line();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
            _lineObject.Stroke = Brushes.Purple;
            _lineObject.StrokeThickness = 1;
            _lineObject.StrokeDashArray = new DoubleCollection() { 2, 1 };
        }
    }
}
