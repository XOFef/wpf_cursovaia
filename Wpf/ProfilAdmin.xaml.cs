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
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для ProfilAdmin.xaml
    /// </summary>
    public partial class ProfilAdmin : Window
    {
        public ProfilAdmin()
        {
            InitializeComponent();
            Nameuser.Text = (string)Application.Current.Properties["UserName"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adMain = new AdminMain();
            adMain.Show();
            this.Close();
        }
    }
}
