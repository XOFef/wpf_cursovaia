﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase _dataBase = new DataBase();
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            TestDes.TextWrapping = TextWrapping.Wrap;
            GoTest.Visibility = Visibility.Hidden;
        }
        private string db_title(int ID)
        {
            _dataBase.openConnection();
            string txt = "";
            string querystringTest = "SELECT Title FROM Tests WHERE ID = @ID";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt = reader["Title"].ToString();
                    }
                    else
                    {
                        txt = "Тест не найден!";
                    }
                }
            }
            _dataBase.closeConnection();
            return txt;
        }

        private string db_des(int ID)
        {
            _dataBase.openConnection();
            string txt = "";
            string querystringTest = "SELECT Description FROM Tests WHERE ID = @ID";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt = reader["Description"].ToString();
                    }
                    else
                    {
                        txt = "Описания нет!";
                    }
                }
            }
            _dataBase.closeConnection();
            return txt;
        }
        private byte[] GetImageFromDatabase(int ID)
        {
            byte[] imageBytes = null;

            _dataBase.openConnection();
            string query = "SELECT Photo FROM Tests WHERE ID = @ID";

            using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        imageBytes = reader["Photo"] as byte[];
                    }
                }
            }
            _dataBase.closeConnection();
            return imageBytes;

        }


        private BitmapSource ByteArrayToBitmapSource(byte[] imageData)
        {
            using (var stream = new MemoryStream(imageData))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Кэшируем изображение
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // Замораживаем объект для использования в разных потоках
                return bitmapImage;
            }
        }

        private void DisplayImage(byte[] imageData)
        {

            if (imageData != null && imageData.Length > 0)
            {
                BitmapSource bitmapSource = ByteArrayToBitmapSource(imageData);
                TestPhoto.Source = bitmapSource;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration Registration = new Registration();
            Registration.Show();
        }

        public static void CloseMain()
        {
            Instance?.Close();
        }

        // запрет на ввод букв
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

        private void Button_Click_FoundId(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(TestID.Text);
            Title.Text = db_title(ID);
            TestDes.Text = db_des(ID);
            byte[] imageBytes = GetImageFromDatabase(ID);
            DisplayImage(imageBytes);
            GoTest.Visibility = Visibility.Visible;
            Application.Current.Properties["ID"] = ID;
        }

        private void GoTest_Click(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            test.Show();
            this.Close();
        }
    }

}
