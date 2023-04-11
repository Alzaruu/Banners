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

namespace Banners5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        loginTableAdapter adapter = new loginTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            var allLog = adapter.GetData().Rows;
            for (int i = 0; i < allLog.Count; i++)
            {
                if (allLog[i][1].ToString() == login.Text && allLog[i][2].ToString() == password.Password)
                {
                    int roleid = (int)allLog[i][3];

                    switch (roleid)
                    {
                        case 1:
                            AdminWin window = new AdminWin();
                            window.Show();
                            break;
                        case 2:
                            VseWin sec = new VseWin(); 
                            sec.Show();
                            break;
                    }
                }
            }
          
        }
    }
}
