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

namespace webbrowserDemo
{
    /// <summary>
    /// frame.xaml 的交互逻辑
    /// </summary>
    public partial class frame : Window
    {
        public frame()
        {
            InitializeComponent();
            frame1.Source = new Uri("http://localhost:8579/Plan/GIndex");
            frame1.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
    }
}
