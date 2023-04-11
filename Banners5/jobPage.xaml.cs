using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для jobPage.xaml
    /// </summary>
    public partial class jobPage : Page
    {
        Job_titleTableAdapter job = new Job_titleTableAdapter();
        public jobPage()
        {
            InitializeComponent();
            jobGr.ItemsSource = job.GetData();
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (jobGr.SelectedItem != null)
            {
                var sel = ((jobGr.SelectedItem) as DataRowView).Row[0];
                job.DeleteQuery((int)sel);
                jobGr.ItemsSource = job.GetData();
            }
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (jobGr.SelectedItem != null)
            {
                var sel = ((jobGr.SelectedItem) as DataRowView).Row[0];
                job.UpdateQuery(name.Text, (int)sel);
                jobGr.ItemsSource = job.GetData();
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            job.InsertQuery(name.Text);
            jobGr.ItemsSource = job.GetData();
        }

        private void jobGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (jobGr.SelectedItem != null) 
            {
                var sel = (jobGr.SelectedItem) as DataRowView;
                name.Text = sel[1].ToString();
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            List<jobPLUS> forImp = serial.MyDeser<List<jobPLUS>>();
            foreach (var item in forImp)
            {
                job.InsertQuery(item.name);
            }
            jobGr.ItemsSource = null;
            jobGr.ItemsSource = job.GetData();
        }
    }
}
