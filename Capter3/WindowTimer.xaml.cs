using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace Capter3
{
    /// <summary>
    /// WindowTimer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowTimer : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;




        public WindowTimer()
        {
            InitializeComponent();
            //DataContext = this;

            
            CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");
            SetTimer();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
            Console.WriteLine(handler);
        }






        private void SetTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (timerSender, timeEvent) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");
            };
            timer.Start();
        }





        
        public string CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }
        protected string currentTime;


  




        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            RenderingEventArgs renderingEventArgs = e as RenderingEventArgs;
            if(renderingEventArgs != null)
            {
                double t = (0.25 * renderingEventArgs.RenderingTime.TotalSeconds) % 1;
                double scale = t < 0.5 ? 2 * t : 2 - 2 * t;
                tbTime.FontSize = 1 + scale * 143;

                byte gray = (byte)(255 * t);
                Color clr = Color.FromArgb(255, gray, gray, gray);
                gridBackgroundBrush.Color = clr;
                //contentGrid.Background = new SolidColorBrush(clr);


                
                gray = (byte)(255-gray);
                clr = Color.FromArgb(255, gray, gray, gray);
                tbForegroundBrush.Color = clr;
                //tbTime.Foreground = new SolidColorBrush(clr);


                tbRainbow.FontSize = 1+(ActualHeight / 8);
                for(int index=0; index< gradientBrush.GradientStops.Count; index++)
                {
                    gradientBrush.GradientStops[index].Offset = index / 7.0 - t;
                }
            }
        }

       





        
    }
}
