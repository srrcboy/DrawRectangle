using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawLibrary
{
    public class CBrokenLine : CLine
    {
        public CBrokenLine(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _lineObject = new Line();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
            _lineObject.Stroke = Brushes.Teal;
            _lineObject.StrokeThickness = 1;
        }
    }
}
