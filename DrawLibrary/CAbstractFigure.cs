using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrawLibrary
{
    public abstract class CAbstractFigure
    {
        protected double _startX;
        protected double _startY;
        protected double _finishX;
        protected double _finishY;

        protected CAbstractFigure(double startX, double startY, double finishY, double finishX)
        {
            _startX = startX;
            _startY = startY;
            _finishY = finishY;
            _finishX = finishX;
        }

        public double StartX
        {
            get { return (_finishX <= _startX) ? _finishX : _startX; }
            set { _startX = value; }
        }

        public double StartY
        {
            get { return (_finishY <= _startY) ? _finishY : _startY; }
            set { _startY = value; }
        }

        public double FinishX
        {
            get { return (_finishX <= _startX) ? _startX : _finishX; }
            set { _finishX = value; }
        }

        public double FinishY
        {
            get { return (_finishY <= _startY) ? _startY : _finishY; }
            set { _finishY = value; }
        }

        public void UpdateCoordinates(double x, double y)
        {
            _finishY = y;
            _finishX = x;
        }

        public abstract void Draw(Canvas targetCanvas);
        public abstract void Move(double x, double y);
    }

}
