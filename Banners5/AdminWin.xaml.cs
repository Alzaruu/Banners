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
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public AdminWin()
        {
            InitializeComponent();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new firmPage();
        }

        private void but2_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new custPage();
        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new empPage();
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new jobPage();
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new prodPage();
        }

        private void but7_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new locPage();
        }

        private void but8_Click(object sender, RoutedEventArgs e)
        {
            forPage.Content = new teamPage();
        }
    }
}
