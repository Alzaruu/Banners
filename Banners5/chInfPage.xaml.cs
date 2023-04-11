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
    /// Логика взаимодействия для chInfPage.xaml
    /// </summary>
    public partial class chInfPage : Page
    {
        check_infTableAdapter chInf = new check_infTableAdapter();
        public chInfPage()
        {
            InitializeComponent();
            chInfGr.ItemsSource = chInf.GetData();
        }
    }
}
