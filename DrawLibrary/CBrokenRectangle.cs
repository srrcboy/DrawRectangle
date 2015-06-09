using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawLibrary
{
    public class CBrokenRectangle:CRectangle
    {
        public CBrokenRectangle(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _rectangleObject = new Rectangle();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
            _rectangleObject.Stroke = Brushes.DarkRed;
            _rectangleObject.StrokeThickness = 2;
            _rectangleObject.Fill = new SolidColorBrush(Colors.LightCoral) { Opacity = 0.5 };
        }
    }
}
