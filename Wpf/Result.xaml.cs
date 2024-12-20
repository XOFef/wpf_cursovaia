using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        DataBase _dataBase = new DataBase();
        public Result()
        {
            InitializeComponent();
            Title.Text = db_title();
            TestDes.Text = db_des();
            Title.TextWrapping = TextWrapping.Wrap;
            TestDes.TextWrapping = TextWrapping.Wrap;
            byte[] imageBytes = GetImageFromDatabase();
            DisplayImage(imageBytes);
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private string db_title()
        {
            _dataBase.openConnection();
            string txt = "";
            string querystringTest = "SELECT Title FROM Results WHERE TestID = @ID and ScoreLow <= @Score and ScoreHight >= @Score";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", (int)Application.Current.Properties["ID"]);
                command.Parameters.AddWithValue("@Score", (int)Application.Current.Properties["Score"]);
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

        private string db_des()
        {
            _dataBase.openConnection();
            string txt = "";
            string querystringTest = "SELECT Description FROM Results WHERE TestID = @ID and ScoreLow <= @Score and ScoreHight >= @Score";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", (int)Application.Current.Properties["ID"]);
                command.Parameters.AddWithValue("@Score", (int)Application.Current.Properties["Score"]);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt = reader["Description"].ToString();

                    }
                }
            }
            _dataBase.closeConnection();
            return txt;
        }
        private byte[] GetImageFromDatabase()
        {
            byte[] imageBytes = null;

            _dataBase.openConnection();
            string querystringTest = "SELECT Photo FROM Results WHERE TestID = @ID and ScoreLow <= @Score and ScoreHight >= @Score";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", (int)Application.Current.Properties["ID"]);
                command.Parameters.AddWithValue("@Score", (int)Application.Current.Properties["Score"]);
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

    }
}
