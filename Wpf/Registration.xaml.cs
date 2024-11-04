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

namespace Wpf
{

    public partial class Registration : Window
    {

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


        // запрет на ввод букв в поле "ваш возраст"
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        // запрет на вставку символов кроме цифр
        private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                string text = (string)e.DataObject.GetData(typeof(String));
                Regex regex = new Regex("[^0-9]+");
                if (regex.IsMatch(text) == true)
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        // Кнопка в регистрации
        //private void Button_Click_Registr(object sender, RoutedEventArgs e)
        //{
        //    string login = TextLogin.Text.Trim();
        //    string Email = TextBoxEmail.Text.Trim();
        //    string pass = TextBoxPassword.Password.Trim();
        //    string gender = GenderBox.Text;
        //    string twopass = twoPass.Password.Trim();
        //    Application.Current.Properties["UserName"] = login;

        //    SolidColorBrush trueColor = new SolidColorBrush();
        //    trueColor.Color =
        //        Color.FromArgb(
        //            255,
        //            138,
        //            212,
        //            199);

        //    //Проверка логина
        //    if (login.Length < 5 && login == "")
        //    {
        //        TextLogin.ToolTip = "Логин слишком короткий!";
        //        TextLogin.BorderBrush = Brushes.Red;
        //    }
        //    else
        //    {
        //        TextLogin.BorderBrush = trueColor;
        //        TextLogin.ToolTip = null;
        //    }

        //    //Проверка почты 
        //    if (Email != "" && IsValidEmail(Email))
        //    {
        //        TextBoxEmail.BorderBrush = trueColor;
        //        TextBoxEmail.ToolTip = null;
        //    }
        //    else {
        //        TextBoxEmail.ToolTip = "Почта введена некорректно!";
        //        TextBoxEmail.BorderBrush = Brushes.Red;
        //    }
        //     bool IsValidEmail(string email)
        //    {
        //        string pattern = @"(@)(.+)$"; // шаблон для проверки почты
        //        return Regex.IsMatch(email, pattern);
        //    }

        //    // Проверка пароля
        //    bool symbPass = false, numPass = false, upPass = false;

        //    if (pass != null) 
        //    {
        //        for (int i = 0; i < pass.Length; i++)
        //        {
        //            if (char.IsUpper(pass[i]))
        //            {
        //                upPass = true;
        //                break;
        //            }
        //        }

        //        if (pass.Contains('-') || pass.Contains('|') || pass.Contains('=') || pass.Contains('%') || pass.Contains('(')
        //                || pass.Contains(')') || pass.Contains('!') || pass.Contains('#') || pass.Contains('@') || pass.Contains('?'))
        //        {
        //            symbPass = true;
        //        }

        //        if (pass.Contains('1') || pass.Contains('2') || pass.Contains('3') || pass.Contains('4') || pass.Contains('5')
        //               || pass.Contains('6') || pass.Contains('7') || pass.Contains('8') || pass.Contains('9') || pass.Contains('0'))
        //        {
        //            numPass = true;
        //        }


        //        if (pass.Length < 8)
        //        {
        //            TextBoxPassword.ToolTip = "В пароле мало символов!";
        //            TextBoxPassword.BorderBrush = Brushes.Red;
        //            TextBoxPassword.Password = "";
        //        }
        //        if (upPass == false)
        //        {
        //            TextBoxPassword.ToolTip = "В пароле нет большой буквы!";
        //            TextBoxPassword.BorderBrush = Brushes.Red;
        //            TextBoxPassword.Password = "";
        //        }
        //        if (numPass == false)
        //        {
        //            TextBoxPassword.ToolTip = "В пароле нет цифры!";
        //            TextBoxPassword.BorderBrush = Brushes.Red;
        //            TextBoxPassword.Password = "";
        //        }
        //        if (symbPass == false)
        //        {
        //            TextBoxPassword.ToolTip = "В пароле нет специальных символов!";
        //            TextBoxPassword.BorderBrush = Brushes.Red;
        //            TextBoxPassword.Password = "";
        //        }
        //        if (symbPass == true && pass.Length > 8 && numPass == true && upPass == true)
        //        {
        //            TextBoxPassword.BorderBrush = trueColor;
        //            TextBoxPassword.ToolTip = null;
        //        }
        //    }
        //    else
        //    {
        //        TextBoxPassword.ToolTip = "Вы не написали пароль!";
        //        TextBoxPassword.BorderBrush = Brushes.Red;
        //    }
            

        //    // Проверка на совпадение повторного пароля
        //    if (twopass != null)
        //    {
        //        if (twopass == pass)
        //        {
        //            twoPass.BorderBrush = trueColor;
        //            twoPass.ToolTip = null;
        //        }
        //        else
        //        {
        //            twoPass.BorderBrush = Brushes.Red;
        //            twoPass.ToolTip = "Пароли не совпадают!";
        //        }
        //    }
        //    else
        //    {
        //        twoPass.BorderBrush = Brushes.Red;
        //        twoPass.ToolTip = "Вы не подтвердили пароль!";
        //    }

        //    if (TextBoxAge.Text != null)
        //    {
        //        string age = TextBoxAge.Text;
        //        // Проверка на возраст
        //        if (age != "")
        //        {
        //            int numAge = Convert.ToInt32(age);
        //            if (numAge < 16)
        //            {
        //                TextBoxAge.BorderBrush = Brushes.Red;
        //                TextBoxAge.ToolTip = "Возраст слишком мал!";
        //            }
        //            else if (numAge > 80)
        //            {
        //                TextBoxAge.BorderBrush = Brushes.Red;
        //                TextBoxAge.ToolTip = "Некорректные данные!";
        //            }
        //            else
        //            {
        //                TextBoxAge.BorderBrush = trueColor;
        //                TextBoxAge.ToolTip = null;
        //            }
        //        }
        //        else
        //        {
        //            TextBoxAge.BorderBrush = Brushes.Red;
        //            TextBoxAge.ToolTip = "Вы не ввели возраст!";
        //        }
        //    }

        //}



        // Кнопка в входе
        private void Button_Click_entrance(object sender, RoutedEventArgs e)
        {
            string loginOrEmail = LoginOrEmail.Text.Trim();
            string pass = password.Password.Trim();
            bool admin = false;

            if(loginOrEmail == "reter" && pass == "reter") { 
            admin = true;
            }

            if (admin == true)
            {

                Application.Current.Properties["UserName"] = LoginOrEmail.Text.Trim();
                AdminMain adminMain = new AdminMain();  
                adminMain.Show();
                MainWindow.CloseMain();

            }
        }
    }
}
