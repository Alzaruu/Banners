using Banners5.BannersDataSetTableAdapters;
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
using Banners5.BannersDataSetTableAdapters;
using System.Data;

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для prodPage.xaml
    /// </summary>
    public partial class prodPage : Page
    {
        productTableAdapter product = new productTableAdapter();
        public prodPage()
        {
            InitializeComponent();
            prodGr.ItemsSource = product.GetData();
        }

        private void prodGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (prodGr.SelectedItem != null)
            {
                var sel = (prodGr.SelectedItem) as DataRowView;
                name.Text = sel[1].ToString();
                size.Text = sel[2].ToString();
                price.Text = sel[3].ToString();
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            product.InsertQuery(name.Text, size.Text, Convert.ToInt32(price.Text));
            prodGr.ItemsSource = product.GetData();
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (prodGr.SelectedItem != null)
            {
                var sel = ((prodGr.SelectedItem) as DataRowView).Row[0];
                product.UpdateQuery(name.Text, size.Text, Convert.ToInt32(price.Text), (int)sel);
                prodGr.ItemsSource = product.GetData();
            }
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (prodGr.SelectedItem != null)
            {
                var sel = ((prodGr.SelectedItem) as DataRowView).Row[0];
                product.DeleteQuery((int)sel);
                prodGr.ItemsSource = product.GetData();
            }
        }
    }
}
