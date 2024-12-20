using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using System.IO;
using System.Collections;


namespace Wpf
{

    public class User
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }

    public partial class ProfilAdmin : Window
    {
        DataBase _dataBase = new DataBase();

        public ProfilAdmin()
        {
            InitializeComponent();
            
            Nameuser.Text = (string)Application.Current.Properties["UserName"];
            db_inf();
            if (Application.Current.Properties["Test"] != null)
            {
                TestName.Text = db_title_One();
                Description.Text = db_Description_One();
                Description.TextWrapping = TextWrapping.Wrap;
                byte[] imageBytes = GetImageFromDatabase();
                DisplayImage(imageBytes);
            }   
            
        }


        private void db_inf()
        {
            // Открываем соединение с базой данных
            _dataBase.openConnection();
            List<User> users = new List<User>();
            int IDu = (string)Application.Current.Properties["User"] == "ret" ? 2 : 1;

            // Параметризованный SQL-запрос
            string query = "SELECT ID, Title FROM Tests WHERE CreatedBy = @CreatedBy";

            using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
            {
                // Устанавливаем значение параметра
                command.Parameters.AddWithValue("@CreatedBy", IDu);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Проверяем наличие данных
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Нет данных для указанного пользователя.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                ID = reader.GetInt32(0), // Получаем значение ID
                                Title = reader.GetString(1) // Получаем значение Title
                            };
                            users.Add(user);
                        }

                        listviewUsers.ItemsSource = users;
                    }
                }
            }
            _dataBase.closeConnection();
            //return users;
        }
        private string db_title_One()
        {
            
            _dataBase.openConnection();
            string txt = "Здесь будет ваш тест"; // Значение по умолчанию
            string querystringTest = "SELECT Title FROM Tests WHERE Title = @TestTitle";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@TestTitle", Application.Current.Properties["Test"]);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt = reader["Title"].ToString();
                    }
                }
            }
            _dataBase.closeConnection();
            return txt;
        }
       


        private string db_Description_One()
        {
            
            _dataBase.openConnection();
            string txt = "Без описания";
            string querystringTest = "SELECT Description FROM Tests WHERE Title = @TestTitle";
            using (SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@TestTitle", Application.Current.Properties["Test"]);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt = reader["Description"].ToString();
                    }
                }
            }
            _dataBase.closeConnection();
           
            return string.IsNullOrEmpty(txt) ? "Без описания" : txt;
        }
       



        private byte[] GetImageFromDatabase()
        {
            byte[] imageBytes = null;

            _dataBase.openConnection();
            string query = "SELECT Photo FROM Tests WHERE Title = @TestTitle";

            using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@TestTitle", Application.Current.Properties["Test"]);
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
                PhotoTest.Source = bitmapSource;
            }
        }
        





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adMain = new AdminMain();
            adMain.Show();
            this.Close();
        }

        private void Button_Click_TestBild(object sender, RoutedEventArgs e)
        {
            TestBild test = new TestBild();
            test.Show();
            this.Close();
        }


    }
}
