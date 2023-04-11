using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.Win32;

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для checkPage.xaml
    /// </summary>
    public partial class checkPage : Page
    {
        check_infTableAdapter chequeInfo = new check_infTableAdapter();
        checkTableAdapter check = new checkTableAdapter();
        productTableAdapter product = new productTableAdapter();
        firmTableAdapter firm = new firmTableAdapter();
        employeeTableAdapter employee = new employeeTableAdapter();
        List<int> items = new List<int>();
        int summ;
        public checkPage()
        {
            InitializeComponent();
            checkGr.ItemsSource = product.GetData();
            firmCbx.ItemsSource = firm.GetData();
            firmCbx.DisplayMemberPath = "fnam";
            firmCbx.SelectedValuePath = "id";
            empCbx.ItemsSource = employee.GetData();
            empCbx.DisplayMemberPath = "name";
            empCbx.SelectedValuePath = "id";
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            int chis;
            chequeInfo.InsertQuery(Convert.ToInt32(money.Text), (int)empCbx.SelectedValue, (int)firmCbx.SelectedValue);
            var id = chequeInfo.GetDataBy1( Convert.ToInt32(money.Text), (int)empCbx.SelectedValue, (int)firmCbx.SelectedValue).Rows[0][0];
            var builder = new StringBuilder(); builder.AppendLine($"{"".PadRight(10, ' ')}ProgectAdvert");
            builder.AppendLine($"{"".PadRight(10, ' ')}Кассовый чек №" + id.ToString()); foreach (var item in items)
            {
                builder.AppendLine($"{"".PadRight(7, ' ')}" + product.GetDataBy3(item).Rows[0][1].ToString() + "--" + product.GetDataBy3(item).Rows[0][3].ToString());

                check.InsertQuery((int)id, item);
            }
            builder.AppendLine($"{"".PadRight(5, ' ')}Итого к оплате: " + summ.ToString()); builder.AppendLine($"{"".PadRight(5, ' ')}Внесено: " + money.Text.ToString());
            builder.AppendLine($"{"".PadRight(5, ' ')}Сдача: " + (Convert.ToInt32(money.Text) - summ).ToString()); SaveFileDialog saveFileDialog = new SaveFileDialog();
            string FilePath; if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName + ".txt";
                StreamWriter streamWriter = new StreamWriter(File.Create(FilePath)); streamWriter.Write(builder.ToString());
                streamWriter.Close(); konCheck.Items.Clear();
                items.Clear(); summ = 0;
                money.Text = null;
                empCbx.Text = null;
                firmCbx.Text = null;
            }
        }

        private void checkGr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (checkGr.SelectedItems != null)
            {
                konCheck.Items.Clear();
                var row = ((checkGr.SelectedItem) as DataRowView).Row[0];
                items.Add((int)row);
                summ += Convert.ToInt32(product.GetDataBy3((int)row).Rows[0][3]);
                itog.Text = summ.ToString();
                foreach (var item in items)
                {
                    konCheck.Items.Add(product.GetDataBy3(item).Rows[0]);
                }
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (konCheck.SelectedItem != null)
            {
                var row = konCheck.SelectedItem as DataRow;
                items.Remove((int)row[0]);
                summ -= Convert.ToInt32(product.GetDataBy3((int)row[0]).Rows[0][3]);
                konCheck.Items.Clear();
                foreach (var item in items)
                {
                    konCheck.Items.Add(product.GetDataBy3(item).Rows[0]);
                }
            }
        }
    }
}
