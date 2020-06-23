using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capter02
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SetTBGradientBrush();

            //LinearGradientBrush linearGradientBrush = tbBlk.Foreground as LinearGradientBrush;
            //linearGradientBrush.EndPoint = new Point(0.5, 1);

            
            drawPolyLine();
        }




        protected virtual void drawPolyLine()
        {
            int angle;
            for(angle = 0; angle<3600; angle++)
            {
                double radians = Math.PI * angle / 180;
                double radius = angle / 10;
                double x = 360 + radius * Math.Sin(radians);
                double y = 360 - radius * Math.Cos(radians);
                polyLine.Points.Add(new Point(x, y));  
            }
        }



        protected void SetTBGradientBrush()
        {
            LinearGradientBrush foregroundBrush = new LinearGradientBrush();
            foregroundBrush.StartPoint = new Point(0, 0);
            foregroundBrush.EndPoint = new Point(1, 0);

            GradientStop gradientStop = new GradientStop();
            gradientStop.Offset = 0;
            gradientStop.Color = Colors.Blue;
            foregroundBrush.GradientStops.Add(gradientStop);


            gradientStop = new GradientStop();
            gradientStop.Offset = 1;
            gradientStop.Color = Colors.Red;
            foregroundBrush.GradientStops.Add(gradientStop);

            tbBlk.Foreground = foregroundBrush;



            LinearGradientBrush backgroundBrush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0)
            };
            backgroundBrush.GradientStops.Add(new GradientStop()
            {
                Offset = 0,
                Color = Colors.Red
            });

            backgroundBrush.GradientStops.Add(new GradientStop()
            {
                Offset = 1,
                Color = Colors.Blue
            });

            MainGrid.Background = backgroundBrush;
        }
    }
}
