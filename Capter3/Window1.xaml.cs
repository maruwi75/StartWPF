﻿using System;
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

namespace Capter3
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        protected Random random = new Random();
        protected byte[] rgb = new byte[3];


        public Window1()
        {
            InitializeComponent();
            
        }

        




        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //widthText.Text = e.NewSize.Width.ToString();
            //heightText.Text = e.NewSize.Height.ToString();

            //widthText.Text = e.NewSize.Width + "(" + Convert.ToInt32(ActualWidth) + ")";
            //heightText.Text = e.NewSize.Height + "(" + Convert.ToInt32(ActualHeight) + ")";
        }
    }
}