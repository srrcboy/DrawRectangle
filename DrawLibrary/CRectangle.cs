using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DrawLibrary
{
    public class CRectangle : CAbstractFigure
    {
        protected Rectangle _rectangleObject;
        
        public CRectangle(double startX, double startY, double finishY, double finishX) : base(startX, startY, finishY, finishX)
        {
            _rectangleObject = new Rectangle();
            _startX = startX;
            _startY = startY;
            _finishX = finishX;
            _finishY = finishY;
        }
        
        public override void Draw(Canvas targetCanvas)
        {
            targetCanvas.Children.Remove(_rectangleObject);
            Canvas.SetLeft(_rectangleObject, StartX);
            Canvas.SetTop(_rectangleObject, StartY);
            _rectangleObject.Width = Math.Abs(FinishX - StartX);
            _rectangleObject.Height = Math.Abs(FinishY - StartY);
            targetCanvas.Children.Add(_rectangleObject);
        }

        public override void Move(double x, double y)
        {
            if (Moving != null) Moving(x,y);
            _startX += x;
            _startY += y;
            _finishX += x;
            _finishY += y;
        }

        public delegate void OnMove(double x, double y);

        public event OnMove Moving;
    }
}
