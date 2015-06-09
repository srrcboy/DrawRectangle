using System.Windows.Controls;
using System.Windows.Shapes;

namespace DrawLibrary
{
    public class CLine : CAbstractFigure
    {
        protected Line _lineObject;

        public CLine(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _lineObject = new Line();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
        }

        public Line LineObject
        {
            get { return _lineObject; }
            set { _lineObject = value; }
        }

        public override void Draw(Canvas targetCanvas)
        {
            targetCanvas.Children.Remove(_lineObject);
            _lineObject.X1 = _startX;
            _lineObject.Y1 = _startY;
            _lineObject.X2 = _finishX;
            _lineObject.Y2 = _finishY;
            targetCanvas.Children.Add(_lineObject);
        }

        public override void Move(double x, double y)
        {
        }

        public void MoveStart(double x, double y)
        {
            _startX += x;
            _startY += y;
        }

        public void MoveFinish(double x, double y)
        {
            _finishX += x;
            _finishY += y;
        }

    }
}
