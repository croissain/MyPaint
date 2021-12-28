using Contract;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rectangle2D
{
    public class Rectangle2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();

        public string Name => "Rectangle";

        public int IconKind => (int)PackIconKind.ChartLineVariant;
        public Brush _Brush { get; set; }
        public int Thickness { get; set; }

        public UIElement Draw()
        {
            var rect = new Rectangle()
            {
                Width = (int)(_rightBottom.X - _leftTop.X),
                Height = (int)(_rightBottom.Y - _leftTop.Y),
                Stroke = _Brush,
                StrokeThickness = Thickness
            };

            Canvas.SetLeft(rect, _leftTop.X);
            Canvas.SetTop(rect, _leftTop.Y);

            return rect;
        }

        public void HandleStart(double x, double y)
        {
            _leftTop = new Point2D() { X = x, Y = y };
        }

        public void HandleEnd(double x, double y)
        {
            _rightBottom = new Point2D() { X = x, Y = y };
        }

        public IShape Clone()
        {
            return new Rectangle2D() { _Brush = new SolidColorBrush(Colors.Red), Thickness = 2};
        }
    }
}
