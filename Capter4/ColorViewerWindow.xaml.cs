using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// ColorViewerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorViewerWindow : Window
    {
        public ColorViewerWindow()
        {
            InitializeComponent();
            Loaded += ColorViewerWindow_Loaded;
        }

        private void ColorViewerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<PropertyInfo> propertyInfos = typeof(Colors).GetTypeInfo().DeclaredProperties;

            foreach(PropertyInfo property in propertyInfos)
            {
                Color clr = (Color)property.GetValue(null);
                ColorItem colorItem = new ColorItem(property.Name, clr);
                stackPanel.Children.Add(colorItem);
            }
        }
    }
}
