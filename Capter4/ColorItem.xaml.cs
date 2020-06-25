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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capter4
{
    /// <summary>
    /// ColorList2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorItem : UserControl
    {

        public ColorItem()
        {
            InitializeComponent();
        }


        public ColorItem(string name, Color color) : this()
        {
            rectangle.Fill = new SolidColorBrush(color);
            tbName.Text = name;
            tbRGB.Text = string.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2}", color.A, color.R, color.G, color.B);
        }
    }
}
