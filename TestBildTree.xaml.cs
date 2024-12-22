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
using Microsoft.Win32;
using System.IO;


namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для TestBildTree.xaml    Результат №1     от
    /// </summary>
    public partial class TestBildTree : Window
    {
        int number = 1;
        DataBase _dataBase = new DataBase();
        public TestBildTree()
        {
            InitializeComponent();
            string questionBox = "Результат №" + number.ToString() + "     от";
            Result.Text = questionBox;
        }
        // РЕЗУЛЬТАТ
        // Чекбокс изображения 
        // когда галочка
        private void CheckBox_Checked_Result(object sender, RoutedEventArgs e)
        {
            buttonImageResult.IsEnabled = true;
            imageControlResult.Visibility = Visibility.Visible;
        }
        // когда нет галочки
        private void CheckBox_Unchecked_Result(object sender, RoutedEventArgs e)
        {
            buttonImageResult.IsEnabled = false;
            imageControlResult.Visibility = Visibility.Collapsed;
        }
        // Чекбокс описания
        // когда галочка
        private void CheckBox_Checked_Two_Result(object sender, RoutedEventArgs e)
        {
            TextBoxResult.IsEnabled = true;
        }
        // когда нет галочки
        private void CheckBox_Unchecked_Two_Result(object sender, RoutedEventArgs e)
        {
            TextBoxResult.IsEnabled = false;
        }
        // Функция для открытия обзора файлов
        private void OpenImageFileDialogResult()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // Показываем диалог и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                imageControlResult.Source = new BitmapImage(new Uri(filePath));
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
        //Кнопка для выбора изображения
        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            OpenImageFileDialogResult();
        }


        private int db_id()
        {
            int TestID;
            _dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystringTest = $"select ID from Tests where Title = '{(string)Application.Current.Properties["Test"]}'";
            SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    TestID = reader.GetInt32(0);
                }
                else
                {
                    TestID = -1;
                }
            }
            return TestID;
        }
            private void db_result()
        {
            var title = Title.Text;
            int lowScore = int.Parse(ScoreLow.Text);
            int hightScore = int.Parse(ScoreHight.Text);
            string Description = TextBoxResult.Text;
            string querystring = null;
            int testID;
            _dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystringResult = $"select ID from Tests where Title = '{(string)Application.Current.Properties["Test"]}' ";
            SqlCommand command = new SqlCommand(querystringResult, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    testID = reader.GetInt32(0);
                }
                else
                {
                    testID = -1;
                }
            }
            _dataBase.openConnection();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = _dataBase.getConnection();

                // Определяем запрос в зависимости от наличия описания и изображения
                if (string.IsNullOrEmpty(Description) && imageControlResult.Source == null)
                {
                    cmd.CommandText = "INSERT INTO Results(TestID, ScoreLow, ScoreHight, Title) VALUES(@TestID, @ScoreLow, @ScoreHight, @Title)";
                    cmd.Parameters.AddWithValue("@TestID", testID);
                    cmd.Parameters.AddWithValue("@ScoreLow", lowScore);
                    cmd.Parameters.AddWithValue("@ScoreHight", hightScore);
                    cmd.Parameters.AddWithValue("@Title", title);
                }
                else if (imageControlResult.Source != null)
                {
                    var imageBuffer = BitmapSourceToByteArray((BitmapSource)imageControlResult.Source);
                    cmd.CommandText = "INSERT INTO Results(TestID, ScoreLow, ScoreHight, Title, Description, Photo) VALUES(@TestID, @ScoreLow, @ScoreHight, @Title, @Description, @Photo)";
                    cmd.Parameters.AddWithValue("@TestID", testID);
                    cmd.Parameters.AddWithValue("@ScoreLow", lowScore);
                    cmd.Parameters.AddWithValue("@ScoreHight", hightScore);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@Photo", imageBuffer);
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Results(TestID, ScoreLow, ScoreHight, Title, Description) VALUES(@TestID, @ScoreLow, @ScoreHight, @Title, @Description)";
                    cmd.Parameters.AddWithValue("@TestID", testID);
                    cmd.Parameters.AddWithValue("@ScoreLow", lowScore);
                    cmd.Parameters.AddWithValue("@ScoreHight", hightScore);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", Description);
                }

                // Выполняем команду
                cmd.ExecuteNonQuery();
            }

            // Закрываем соединение
            _dataBase.closeConnection();
        }




        private void Button_Click_NewResult(object sender, RoutedEventArgs e)
        {
            db_result();
            number += 1;
            string questionBox = "Результат №" + number.ToString() + "     от";
            Result.Text = questionBox;
            Title.Text = "";
            TextBoxResult.Text = "";
            imageControlResult.Source = null;
            ScoreLow.Text = "";
            ScoreHight.Text = "";
        }

        private void Button_Click_Ready(object sender, RoutedEventArgs e)
        {
            db_result();
            int id = db_id();
            MessageBox.Show($"ID созданного теста: '{id}'");
            AdminMain adminMain = new AdminMain();
            adminMain.Show();
            this.Close();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            TestBildTwo testBildTwo = new TestBildTwo();    
            testBildTwo.Show();
            this.Close();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
             _dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            int TestID, QuestionID;
            string querystringTest = $"select ID from Tests where Title = '{(string)Application.Current.Properties["Test"]}'";
            SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    TestID = reader.GetInt32(0);
                }
                else
                {
                    TestID = -1;
                }
            }
            querystringTest = $"select ID from Questions where TestsID = '{TestID}'";
            command = new SqlCommand(querystringTest, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    QuestionID = reader.GetInt32(0);
                }
                else
                {
                    QuestionID = -1;
                }
            }

            string querystringAnswer= $"delete from Answers where QuestionsID = '{QuestionID}' ";
            string querystringQuestion = $"delete from Questions where TestsID = '{TestID}' ";
            string querystringDelete = $"delete from Tests where ID = '{TestID}' ";
            SqlCommand cmd = new SqlCommand(querystringAnswer, _dataBase.getConnection());
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(querystringQuestion, _dataBase.getConnection());
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(querystringDelete, _dataBase.getConnection());
            cmd.ExecuteNonQuery();
            _dataBase.closeConnection();

            AdminMain main = new AdminMain();
            main.Show();
            this.Close();
        }
    }
}
