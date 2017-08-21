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

namespace webbrowserDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(textBox.Text);
            string sss = "项目";
            web1.Navigate(uri);
            MessageBox.Show(@"file:///D:/%E9%A1%B9%E7%9B%AE/Code/Bin/KJEditorCZY/L43L45L30L37L30L36L34L31L37L41L30L30L4FL42L41L41L41/L43L45L30L37L30L36L34L31L37L41L30L30L4FL42L41L41L41.html");
        }
    }
}
