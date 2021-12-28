using Contract;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Line2D
{
    public class Line2D : IShape
    {
        private Point2D _start = new Point2D();
        private Point2D _end = new Point2D();

        public string Name => "Line";
        public int IconKind => (int)PackIconKind.ChartLineVariant;
        public Brush _Brush { get; set; }
        public int Thickness { get; set; }

        public void HandleStart(double x, double y)
        {
            _start = new Point2D() { X = x, Y = y };
        }

        public void HandleEnd(double x, double y)
        {
            _end = new Point2D() { X = x, Y = y };
        }

        public UIElement Draw()
        {
            Line l = new Line()
            {
                X1 = _start.X,
                Y1 = _start.Y,
                X2 = _end.X,
                Y2 = _end.Y,
                StrokeThickness = Thickness,
                Stroke = _Brush,
            };

            return l;
        }

        public IShape Clone()
        {
            return new Line2D() { _Brush = new SolidColorBrush(Colors.Red), Thickness = 2 };
        }
    }
}
