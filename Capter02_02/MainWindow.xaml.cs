using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace Capter02_02
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DrawPath();
        }




        protected void DrawPath()
        {
            string s = "M 0 0 L 0 100 M 0 50 L 50 50 M 50 0 L 50 100";
                   s += "M 125 0 C 60 -10, 60 60, 125 50, 60 40, 60 110, 125 100";
            s += "M 150 0 L 150 100, 200 100";
            s += "M 225 0 L 225 100, 275 100";
            s += "M 300 50 A 25 50 0 1 0 300 49.9";
            helloPath.Stroke = Brushes.Moccasin;
            helloPath.Data = PathMarkupToGeometry(s);
        }



        protected Geometry PathMarkupToGeometry(string pPathData)
        {
            string xaml =
               "<Path " +
               "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
               "<Path.Data>" + pPathData + "</Path.Data></Path>";

            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(xaml);
            MemoryStream stream = new MemoryStream(byteArray);


            System.Windows.Shapes.Path path = XamlReader.Load(stream) as System.Windows.Shapes.Path;
            Geometry geometry = path.Data;
            path.Data = null;
            return geometry;

        }
    }
}
