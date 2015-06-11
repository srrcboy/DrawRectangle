using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using DrawLibrary;

namespace DrawRectangle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CRectangle _currentRectangle = null;
        private CRectangle _startRectangle = null;
        private CRectangle _finishRectangle = null;
        private CLine _currentLine = null;
        private List<CRectangle> _listRectangles = new List<CRectangle>();
        private List<CLine> _listLines = new List<CLine>();
        private List<CLink> _listLinks = new List<CLink>();
        private bool moving = false;
        private double _startX;
        private double _startY;
        private FigureType _figureType;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cnvsDraw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UpdatePosition(sender, e);
            if (rbtnRectangle.IsChecked == true)
            {
                _figureType = FigureType.Rectangle;
                _currentRectangle = captureRectangle(_startX, _startY);
                if (_currentRectangle != null)
                {
                    moving = true;
                }
                else
                {
                    _currentRectangle = CreateRectangle((bool)rbtnLineDashed.IsChecked);
                }
            }
            else if (rbtnLine.IsChecked == true)
            {
                _figureType = FigureType.Line;
                _startRectangle = captureRectangle(_startX, _startY);
                _currentLine = CreateLine((bool)rbtnLineDashed.IsChecked);
            }
        }

        private CLine CreateLine(bool lineType)
        {
            if (lineType)
            {
                return new CDashedLine(_startX, _startY, _startX, _startY);
            }
            else
            {
                return new CBrokenLine(_startX, _startY, _startX, _startY);
            }
        }

        private CRectangle CreateRectangle(bool lineType)
        {
            if (lineType)
            {
                return new CDashedRectangle(_startX, _startY, _startX, _startY);
            }
            else
            {
                return new CBrokenRectangle(_startX, _startY, _startX, _startY);
            }
        }

        private CRectangle captureRectangle(double startX, double startY)
        {
            return _listRectangles.LastOrDefault(
                   o =>
                       (o.StartX <= startX) &&
                       (o.FinishX >= startX) &&
                       (o.StartY <= startY) &&
                       (o.FinishY >= startY));
        }

        private void UpdatePosition(object sender, MouseEventArgs e)
        {
            _startX = e.GetPosition((Canvas)sender).X;
            _startY = e.GetPosition((Canvas)sender).Y;
        }

        private void cnvsDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                switch (_figureType)
                {
                    case FigureType.Rectangle:
                        if (moving) 
                        {
                            double differenceX = e.GetPosition((Canvas) sender).X - _startX;
                            double differenceY = e.GetPosition((Canvas) sender).Y - _startY;
                            _currentRectangle.Move(differenceX, differenceY);
                            UpdatePosition(sender, e);
                            foreach (var line in _listLines)
                            {
                                line.Draw((Canvas)sender);
                            }
                        }
                        else
                        {
                            _currentRectangle.UpdateCoordinates(e.GetPosition((Canvas) sender).X,
                                e.GetPosition((Canvas) sender).Y);
                        }

                        if ((_currentRectangle.StartX > 0) && (_currentRectangle.StartY > 0) && (_currentRectangle.FinishX < 350) && (_currentRectangle.FinishY < 200))
                        {
                            _currentRectangle.Draw((Canvas) sender);
                        }
                        break;

                    case FigureType.Line:
                        _currentLine.UpdateCoordinates(e.GetPosition((Canvas) sender).X,
                            e.GetPosition((Canvas) sender).Y);
                        _currentLine.Draw((Canvas) sender);
                        break;
                }
            }
        }

        private void cnvsDraw_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (rbtnRectangle.IsChecked == true)
            {
                _listRectangles.Add(_currentRectangle);
            }
            else if (rbtnLine.IsChecked == true)
            {
                _finishRectangle = captureRectangle(e.GetPosition((Canvas)sender).X, e.GetPosition((Canvas)sender).Y);

                var existLink = _listLinks.FirstOrDefault(
                    o => ((o.FirstRectangle == _startRectangle) && (o.SecondRectangle == _finishRectangle)) || ((o.FirstRectangle == _finishRectangle) && (o.SecondRectangle == _startRectangle))); 

                if ((_startRectangle != null) && (_finishRectangle != null) && (_currentLine != null) && (_startRectangle != _finishRectangle) && (existLink == null))
                {
                    _listLinks.Add(new CLink(_startRectangle, _finishRectangle, _currentLine));
                    _startRectangle.Moving += _currentLine.MoveStart;
                    _finishRectangle.Moving += _currentLine.MoveFinish;
                    _listLines.Add(_currentLine);
                }
                else if (_currentLine != null)
                {
                     cnvsDraw.Children.Remove(_currentLine.LineObject);
                }
            }
            moving = false;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cnvsDraw.Children.Clear();
            _listLinks.Clear();
            _listLines.Clear();
            _listRectangles.Clear();
        }
    }
}
