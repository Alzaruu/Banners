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
    /// Логика взаимодействия для custPage.xaml
    /// </summary>
    public partial class custPage : Page
    {

        customerTableAdapter customer = new customerTableAdapter();
        public custPage()
        {
            InitializeComponent();
            custGr.ItemsSource = customer.GetData();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            customer.InsertQuery(sur.Text,name.Text,last.Text);
            custGr.ItemsSource=customer.GetData();
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (custGr.SelectedItem != null)
            {
                var sel = ((custGr.SelectedItem) as DataRowView).Row[0];
                customer.UpdateQuery(sur.Text, name.Text, last.Text, (int)sel);
                custGr.ItemsSource = customer.GetData();
            }
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (custGr.SelectedItem != null)
            {
                var sel = ((custGr.SelectedItem) as DataRowView).Row[0];
                customer.DeleteQuery((int)sel);
                custGr.ItemsSource = customer.GetData();
            }
        }

        private void custGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (custGr.SelectedItem != null)
            {
                var sel = custGr.SelectedItem as DataRowView;
                sur.Text = sel.Row[1].ToString();
                name.Text = sel.Row[2].ToString();
                last.Text = sel[3].ToString();
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            List<custPLUS> forImp = serial.MyDeser<List<custPLUS>>();
            foreach (var item in forImp)
            {
                customer.InsertQuery(item.surname, item.name, item.lastname);
            }
            custGr.ItemsSource = null;
            custGr.ItemsSource = customer.GetData();
        }
    }
}
