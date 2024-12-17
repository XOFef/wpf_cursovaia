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
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data;


namespace Wpf
{
    public partial class TestBild : Window
    {

        DataBase _dataBase = new DataBase();
        public TestBild()
        {
            InitializeComponent();
        }

        private void Button_Click_Profil(object sender, RoutedEventArgs e)
        {
            AdminMain admin = new AdminMain();
            admin.Show();
            this.Close();
        }

        // ВСТУПЛЕНИЕ
        // Чекбокс изображения 
        // когда галочка
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            buttonImage.IsEnabled = true;
            imageControl.Visibility = Visibility.Visible;
        }
        // когда нет галочки
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            buttonImage.IsEnabled = false;
            imageControl.Visibility = Visibility.Collapsed;
        }

        // Чекбокс описания
        // когда галочка
        private void CheckBox_Checked_Two(object sender, RoutedEventArgs e)
        {
            TextBox.IsEnabled = true;
        }
        // когда нет галочки
        private void CheckBox_Unchecked_Two(object sender, RoutedEventArgs e)
        {
            TextBox.IsEnabled = false;
        }

        //Функция для открытия обзора файлов
        private void OpenImageFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // Показываем диалог и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;
                imageControl.Source = new BitmapImage(new Uri(filePath));
            }
        }



        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }








        // Кнопка для выбора изображения
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                OpenImageFileDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AdminMain admin = new AdminMain();
            admin.Show();
            this.Close();
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            var Title = Name.Text;
            string Description = TextBox.Text;
            int userId;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystringadmin = $"select ID from Users where Email = '{(string)Application.Current.Properties["UserName"]}' ";
            SqlCommand command = new SqlCommand(querystringadmin, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            _dataBase.openConnection();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(0);                                 
                }
                else
                {
                    userId = -1; 
                }
            }
            string querystring;
            if (string.IsNullOrEmpty(Description) && imageControl.Source == null)
            {
                querystring = $"INSERT INTO Tests(Title, CreatedBy) VALUES('{Title}', '{userId}')";
            }
            else if (imageControl.Source != null)
            {
                var imageBuffer = BitmapSourceToByteArray((BitmapSource)imageControl.Source);
                querystring = $"INSERT INTO Tests(Title, Description, Photo, CreatedBy) VALUES('{Title}', '{Description}', '{imageBuffer}', '{userId}')";
            }
            else
            {
                querystring = $"INSERT INTO Tests(Title, Description, CreatedBy) VALUES('{Title}', '{Description}', '{userId}')";
            }
            SqlCommand cmd = new SqlCommand(querystring, _dataBase.getConnection());      
            cmd.ExecuteNonQuery();
            
            Application.Current.Properties["Test"] = Title;
            _dataBase.closeConnection();

            TestBildTwo testBildTwo = new TestBildTwo();
            testBildTwo.Show();
            this.Close();
        }
    }
}
