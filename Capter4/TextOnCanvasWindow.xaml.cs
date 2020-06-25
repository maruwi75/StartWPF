using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Capter4
{
    /// <summary>
    /// TextOnCanvasWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TextOnCanvasWindow : Window
    {
        public TextOnCanvasWindow()
        {
            InitializeComponent();
            this.MouseDown += TextOnCanvasWindow_MouseDown;
        }

        private void TextOnCanvasWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            Ellipse ellipse = new Ellipse()
            {
                Width = 3,
                Height = 3,
                Fill = Foreground
            };

            Canvas.SetLeft(ellipse, point.X);
            Canvas.SetTop(ellipse, point.Y);
            canvas.Children.Add(ellipse);

            TextBlock tb = new TextBlock()
            {
                Text = string.Format("({0}x{1})", Convert.ToInt32(point.X), Convert.ToInt32(point.Y)),
                FontSize = 12
            };

            tb.SetValue(Canvas.LeftProperty, point.X);
            tb.SetValue(Canvas.TopProperty, point.Y);
            canvas.Children.Add(tb);

        }
    }
}

