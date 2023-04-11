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
    /// Логика взаимодействия для firmPage.xaml
    /// </summary>
    public partial class firmPage : Page
    {
        firmTableAdapter firm = new firmTableAdapter();
        public firmPage()
        {
            InitializeComponent();
            firmGr.ItemsSource = firm.GetData();
        }

        private void firmGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firmGr.SelectedItem != null)
            {
                var sel = firmGr.SelectedItem as DataRowView;
                nazv.Text = sel.Row[1].ToString();
                forLok.Text= sel.Row[2].ToString();
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            firm.InsertQuery(text.Text, Convert.ToInt32(forLok.Text));
            firmGr.ItemsSource=firm.GetData();
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (firmGr.SelectedItem != null)
            {
                var sel = ((firmGr.SelectedItem) as DataRowView).Row[0];
                firm.UpdateQuery(text.Text, Convert.ToInt32(forLok.Text), (int)sel);
                firmGr.ItemsSource=firm.GetData();

            }
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (firmGr.SelectedItem != null)
            {
                var sel = ((firmGr.SelectedItem) as DataRowView).Row[0];
                firm.DeleteQuery((int)sel);
                firmGr.ItemsSource = firm.GetData();
            }
        }
    }
}
