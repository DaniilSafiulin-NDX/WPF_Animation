using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfButtonAnimation.MyCode
{
    class WormAnimation
    {
        private readonly Storyboard storyboard = new Storyboard();
        private readonly FrameworkElement parent;
        private readonly FrameworkElement worm;
        private readonly double wormFirstHeight;
        private double time = 0.8;

        public WormAnimation(FrameworkElement parent, FrameworkElement fe, int framerate)
        {
            this.parent = parent;
            worm = fe;
            wormFirstHeight = worm.Height;

            // Частота кадров.
            Timeline.SetDesiredFrameRate(storyboard, framerate);
        }

        // Ширина увеличивается до правого края.
        // Высота равна первоначальному размеру.
        private void Step1()
        {
            worm.Height = wormFirstHeight;

            var width = WidthAnimation(worm.ActualWidth, parent.ActualWidth);
            storyboard.Children.Add(width);

            storyboard.Completed += Step1_Completed;
            storyboard.Begin(worm);
        }

        private void Step1_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step1_Completed;
            Step2();
        }


        // Занимает крайнее правое положение.
        // Уменьшается по ширине до размера первоначальной высоты. 
        private void Step2()
        {
            worm.HorizontalAlignment = HorizontalAlignment.Right;

            var width = WidthAnimation(worm.ActualWidth, wormFirstHeight);
            storyboard.Children.Add(width);

            storyboard.Completed += Step2_Completed;
            storyboard.Begin(worm);
        }


        private void Step2_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step2_Completed;
            Step3();
        }



        // Закрепляет ширину равную первоначальной высоте.
        // Растягивается по высоте вниз.
        private void Step3()
        {
            worm.Width = wormFirstHeight;

            var height = HeightAnimation(wormFirstHeight, parent.ActualHeight);
            storyboard.Children.Add(height);

            storyboard.Completed += Step3_Completed;
            storyboard.Begin(worm);
        }

        private void Step3_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step3_Completed;
            Step4();
        }


        // Занимает крайнее нижнее положение.
        // Уменьшается до первоначальной высоты.
        private void Step4()
        {
            worm.VerticalAlignment = VerticalAlignment.Bottom;

            var height = HeightAnimation(worm.ActualHeight, wormFirstHeight);
            storyboard.Children.Add(height);

            storyboard.Completed += Step4_Completed;
            storyboard.Begin(worm);
        }

        private void Step4_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step4_Completed;
            Step5();
        }


        // Высота закрепляется равной первоначальной.
        // Ширина увеличивается до крайнего левого положения.
        private void Step5()
        {
            worm.Height = wormFirstHeight;

            var width = WidthAnimation(wormFirstHeight, parent.ActualWidth);
            storyboard.Children.Add(width);

            storyboard.Completed += Step5_Completed;
            storyboard.Begin(worm);
        }

        private void Step5_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step5_Completed;
            Step6();
        }


        // Закрепляется в крайнем левом положении.
        // Ширина уменьшается до размера первоначальной высоты.
        private void Step6()
        {
            worm.HorizontalAlignment = HorizontalAlignment.Left;

            var width = WidthAnimation(worm.ActualWidth, wormFirstHeight);
            storyboard.Children.Add(width);

            storyboard.Completed += Step6_Completed;
            storyboard.Begin(worm);
        }

        private void Step6_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step6_Completed;
            Step7();
        }



        // Ширина закрепляется равной высоте.
        // Растягивается до верхнего положения.
        private void Step7()
        {
            worm.Width = wormFirstHeight;

            var height = HeightAnimation(worm.ActualHeight, parent.ActualHeight);
            storyboard.Children.Add(height);

            storyboard.Completed += Step7_Completed;
            storyboard.Begin(worm);
        }

        private void Step7_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step7_Completed;
            Step8();
        }

        // Занимает крайнее верхнее положение.
        // Высота стягивается до первоначальной высоты.
        private void Step8()
        {
            worm.VerticalAlignment = VerticalAlignment.Top;

            var height = HeightAnimation(worm.ActualHeight, wormFirstHeight);
            storyboard.Children.Add(height);

            storyboard.Completed += Step8_Completed;
            storyboard.Begin(worm);
        }

        private void Step8_Completed(object sender, EventArgs e)
        {
            storyboard.Children.Clear();
            storyboard.Completed -= Step8_Completed;

            LetsGo();
        }



        public void LetsGo()
        {
            Init();

            Step1();
        }


        #region Вспомогательные методы 

        private void Init()
        {
            storyboard.Completed -= Step1_Completed;
            storyboard.Completed -= Step2_Completed;
            storyboard.Completed -= Step3_Completed;
            storyboard.Completed -= Step4_Completed;
            storyboard.Completed -= Step5_Completed;
            storyboard.Completed -= Step6_Completed;
            storyboard.Completed -= Step7_Completed;
            storyboard.Completed -= Step8_Completed;

            storyboard.Children.Clear();
        }


        private DoubleAnimation WidthAnimation(double from, double to)
        {
            var width = new DoubleAnimation
            {
                From = from,
                To = to,
                FillBehavior = FillBehavior.HoldEnd,
                Duration = TimeSpan.FromSeconds(time)
            };
            Storyboard.SetTargetName(width, worm.Name);
            Storyboard.SetTargetProperty(width, new PropertyPath(Button.WidthProperty));

            return width;
        }

        private DoubleAnimation HeightAnimation(double from, double to)
        {
            var height = new DoubleAnimation
            {
                From = from,
                To = to,
                FillBehavior = FillBehavior.HoldEnd,
                Duration = TimeSpan.FromSeconds(time)
            };
            Storyboard.SetTargetName(height, worm.Name);
            Storyboard.SetTargetProperty(height, new PropertyPath(Button.HeightProperty));

            return height;
        }

        #endregion
    }
}
