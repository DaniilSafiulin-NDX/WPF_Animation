using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;


namespace WpfButtonAnimation.MyCode
{
    static class Moving
    {
        public static void MoveTo(FrameworkElement fe, double x, double y)
        {
            double speed = 250; // единиц в сек

            double leftInit = Canvas.GetLeft(fe);
            double topInit = Canvas.GetTop(fe);

            double X = Math.Abs(x - leftInit);
            double Y = Math.Abs(y - topInit);
            double quart = Math.Sqrt(X * X + Y * Y);

            double time = quart / speed;


            var left = new DoubleAnimation
            {
                From = leftInit,
                To = x,
                Duration = new Duration(TimeSpan.FromSeconds(time))
            };

            var top = new DoubleAnimation
            {
                From = topInit,
                To = y,
                Duration = new Duration(TimeSpan.FromSeconds(time))
            };

            fe.BeginAnimation(Canvas.LeftProperty, left);
            fe.BeginAnimation(Canvas.TopProperty, top);
        }
    }
}
