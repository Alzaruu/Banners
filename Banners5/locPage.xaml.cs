using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;
using Banners5.BannersDataSetTableAdapters;

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для locPage.xaml
    /// </summary>
    public partial class locPage : Page
    {
        locationTableAdapter locatoin = new locationTableAdapter();
        firmTableAdapter firm = new firmTableAdapter();
        public locPage()
        {
            InitializeComponent();
            locGr.ItemsSource = locatoin.GetDataBy3();
            firmCb.ItemsSource = firm.GetData();
            firmCb.DisplayMemberPath = "fnam";
            firmCb.SelectedValuePath = "id";
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            locatoin.InsertQuery(adress.Text, (int)firmCb.SelectedValue);
            locGr.ItemsSource = locatoin.GetDataBy3();
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (locGr.SelectedItem != null)
            {
                var sel = ((locGr.SelectedItem) as DataRowView).Row[0];
                locatoin.UpdateQuery(adress.Text, (int)firmCb.SelectedValue, (int)sel);
                locGr.ItemsSource = locatoin.GetDataBy3();
            }
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (locGr.SelectedItem != null)
            {
                var sel = ((locGr.SelectedItem) as DataRowView).Row[0];
                locatoin.DeleteQuery((int)sel);
                locGr.ItemsSource = locatoin.GetDataBy3();
            }
        }

        private void locGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (locGr.SelectedItem != null)
            {
                var sel = (locGr.SelectedItem) as DataRowView;
                adress.Text = sel[1].ToString();
                firmCb.SelectedValue = (int)sel[2];
            }
        }
    }
}