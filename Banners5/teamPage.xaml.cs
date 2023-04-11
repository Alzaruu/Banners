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
    /// Логика взаимодействия для teamPage.xaml
    /// </summary>
    public partial class teamPage : Page
    {
        teamTableAdapter team = new teamTableAdapter();
        firmTableAdapter firms = new firmTableAdapter();
        employeeTableAdapter employees = new employeeTableAdapter();
        public teamPage()
        {
            InitializeComponent();
            teamGr.ItemsSource = team.GetDataBy3();
            employee.ItemsSource = employees.GetData();
            employee.DisplayMemberPath = "surn";
            employee.SelectedValuePath = "id";
            firm.ItemsSource = firms.GetData();
            firm.DisplayMemberPath = "fnam";
            firm.SelectedValuePath = "id";
        }

        private void teamGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (teamGr.SelectedItem != null)
            {
                var sel = (teamGr.SelectedItem) as DataRowView;
                employee.SelectedValue = (int)sel[1];
                firm.SelectedValue = (int)sel[2];
            }
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            team.InsertQuery((int)employee.SelectedValue, (int)firm.SelectedValue);
            teamGr.ItemsSource = team.GetData();
        }

        private void udal_Click(object sender, RoutedEventArgs e)
        {
            if (teamGr.SelectedItem != null)
            {
                var sel = ((teamGr.SelectedItem) as DataRowView).Row[0];
                team.DeleteQuery((int)sel);
                teamGr.ItemsSource = team.GetData();
            }
        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (teamGr.SelectedItem != null)
            {
                var sel = ((teamGr.SelectedItem) as DataRowView).Row[0];
                team.UpdateQuery((int)employee.SelectedValue, (int)firm.SelectedValue, (int)sel);
                teamGr.ItemsSource = team.GetData();
            }
        }
    }
}
