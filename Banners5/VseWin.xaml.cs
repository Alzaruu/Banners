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

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для VseWin.xaml
    /// </summary>
    public partial class VseWin : Window
    {
        public VseWin()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            forPag.Content = new checkPage();
        }

        private void checkInf_Click(object sender, RoutedEventArgs e)
        {
            forPag.Content = new chInfPage();
        }

        private void emp_Click(object sender, RoutedEventArgs e)
        {
            forPag.Content = new custPage();
        }
    }
}
