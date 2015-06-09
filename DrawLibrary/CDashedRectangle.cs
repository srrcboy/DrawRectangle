using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace DrawLibrary
{
    public class CDashedRectangle : CRectangle
    {
        public CDashedRectangle(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _rectangleObject = new Rectangle();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
            _rectangleObject.Stroke = Brushes.Gray;
            _rectangleObject.StrokeDashArray = new DoubleCollection() {3, 0.5, 2};
            _rectangleObject.StrokeThickness = 2;
            _rectangleObject.Fill = new SolidColorBrush(Colors.Azure) { Opacity = 0.5 };

        }
    }
}
