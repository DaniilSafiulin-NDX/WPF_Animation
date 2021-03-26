using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfButtonAnimation.MyCode;

//====================================================
// Описание работы классов и методов исходника на:
// https://www.interestprograms.ru
// Исходные коды программ и игр
//====================================================

namespace WpfButtonAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WormAnimation wormAnimation;
        readonly Button[] buttons = new Button[9];

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Width = buttons[i].Height = 24;
                buttons[i].Content = i + 1;
                Canvas.SetLeft(buttons[i], 0);
                Canvas.SetTop(buttons[i], 24 * i);
                fieldMoving.Children.Add(buttons[i]);
            }

            wormAnimation = new WormAnimation(gridAquarium, earthworm, 60);
        }

        bool horizontal = true;
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                double temp = (buttons[i].Width + 1) * i;

                if (horizontal == true) Moving.MoveTo(buttons[i], temp, 0);
                else Moving.MoveTo(buttons[i], 0, temp);
            }

            horizontal = !horizontal;
        }

        private void gridAquarium_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            wormAnimation.LetsGo();
        }
    }
}
