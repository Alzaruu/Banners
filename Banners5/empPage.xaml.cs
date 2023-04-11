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
using Banners5.BannersDataSetTableAdapters;

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для empPage.xaml
    /// </summary>
    public partial class empPage : Page
    {
        employeeTableAdapter employee = new employeeTableAdapter();
        Job_titleTableAdapter job = new Job_titleTableAdapter();
        public empPage()
        {
            InitializeComponent();
            empGr.ItemsSource = employee.GetDataBy3();
            jobCbx.ItemsSource = job.GetData();
            jobCbx.DisplayMemberPath = "Jname";
            jobCbx.SelectedValuePath = "id";
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (empGr.SelectedItem != null)
            {
                var sel = ((empGr.SelectedItem) as DataRowView).Row[0];
                employee.DeleteQuery((int)sel);
                empGr.ItemsSource = employee.GetDataBy3();
            }
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (empGr.SelectedItem != null)
            {
                var sel = ((empGr.SelectedItem) as DataRowView).Row[0];
                employee.UpdateQuery(sur.Text,name.Text,last.Text,(int)jobCbx.SelectedValue, (int)sel);
                empGr.ItemsSource = employee.GetDataBy3();
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            employee.InsertQuery(sur.Text,name.Text,last.Text, (int)jobCbx.SelectedValue);
            empGr.ItemsSource = employee.GetDataBy3(); 
        }

        private void empGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (empGr.SelectedItem!= null)
            {
                var sel = (empGr.SelectedItem) as DataRowView;
                sur.Text = sel.Row[1].ToString();
                name.Text = sel.Row[2].ToString();
                last.Text = sel.Row[3].ToString();
                jobCbx.SelectedValue= (int)sel[4];
            }
        }
    }
}
