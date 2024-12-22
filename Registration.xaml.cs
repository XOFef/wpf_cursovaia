using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Wpf
{

    public partial class Registration : Window
    {

        DataBase _dataBase = new DataBase();

        public string MyVariable { get; set; }
        private string log;
        public Registration()
        {
            InitializeComponent();
            //log = TextLogin.Text.Trim();
            //MyVariable = log;
        }

        

        // закрытие окна при нажатии вне окна
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            Close();
        }

        private void Grid_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        // открытие окна с "забыли пароль"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lossPassword lossPassword = new lossPassword();
            lossPassword.Show();
        }



        // Кнопка в входе
        private void Button_Click_entrance(object sender, RoutedEventArgs e)
        {
            string loginOrEmail = LoginOrEmail.Text.Trim();
            string pass = password.Password.Trim();
            bool admin = false;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select ID, Email, Password from Users where Email = '{loginOrEmail}' and Password = '{pass}'";

            SqlCommand command = new SqlCommand(querystring, _dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1) {
                admin = true;
            }

            if (admin == true)
            {
                Application.Current.Properties["UserName"] = LoginOrEmail.Text.Trim();
                AdminMain adminMain = new AdminMain();
                adminMain.Show();
                MainWindow.CloseMain();
            }
            else {
                LoginOrEmail.BorderBrush = Brushes.Red;
                password.BorderBrush = Brushes.Red;
                LoginOrEmail.ToolTip = "Некорректные данные!";
                password.ToolTip = "Некорректные данные!";
            }
        }
    }
}
