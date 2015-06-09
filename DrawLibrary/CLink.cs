using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawLibrary
{
    public class CLink
    {
        private CRectangle _firstRectangle;
        private CRectangle _secondRectangle;
        private CLine _line;

        public CLink(CRectangle firstRectangle, CRectangle secondRectangle, CLine line)
        {
            _firstRectangle = firstRectangle;
            _secondRectangle = secondRectangle;
            _line = line;
        }

        public CRectangle FirstRectangle
        {
            get { return _firstRectangle; }
            set { _firstRectangle = value; }
        }

        public CRectangle SecondRectangle
        {
            get { return _secondRectangle; }
            set { _secondRectangle = value; }
        }

        public CLine Line
        {
            get { return _line; }
            set { _line = value; }
        }


    }
}
