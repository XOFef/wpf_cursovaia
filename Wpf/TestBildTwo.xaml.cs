using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Win32;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для TestBildTwo.xaml
    /// </summary>
    public partial class TestBildTwo : Window
    {
        int number = 1;
        DataBase _dataBase = new DataBase();
        public TestBildTwo()
        {
            InitializeComponent();
            string questionBox = "Вопрос №" + number.ToString();
            question.Text = questionBox;
        }

        private void Button_Click_Profil(object sender, RoutedEventArgs e)
        {
            AdminMain admin = new AdminMain();
            admin.Show();
            this.Close();
        }

        // ТЕСТ
        // Взаимодействие с текстбокс (когда фокус)
        private void MyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt.Text == "текст вопроса")
            {
                txt.Text = "";
                txt.Foreground = Brushes.Black; // Меняем цвет текста на черный при фокусе
            }
        }
        // Взаимодействие с текстбокс (когда нет фокуса)
        private void MyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "текст вопроса";
                txt.Foreground = Brushes.LightGray; // Возвращаем светло-серый цвет
            }
        }
        // Чекбокс изображения 
        // когда галочка
        private void CheckBox_Checked_Test(object sender, RoutedEventArgs e)
        {
            buttonImageTest.IsEnabled = true;
            imageControltest.Visibility = Visibility.Visible;
        }
        // когда нет галочки
        private void CheckBox_Unchecked_Test(object sender, RoutedEventArgs e)
        {
            buttonImageTest.IsEnabled = false;
            imageControltest.Visibility = Visibility.Collapsed;
        }
        // Функция для открытия обзора файлов
        private void OpenImageFileDialogTest()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // Показываем диалог и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                imageControltest.Source = new BitmapImage(new Uri(filePath));
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
        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            OpenImageFileDialogTest();
        }


        private void db_test()
        {
            var question = txt.Text;
            string querystring = null;
            int testID;
            _dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystringTest = $"select ID from Tests where Title = '{(string)Application.Current.Properties["Test"]}' ";
            SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection());
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
            if (imageControltest.Source == null)
            {
                querystring = $"INSERT INTO Questions(QuestionText, TestsID) VALUES('{question}', '{testID}')";
            }
            else if (imageControltest.Source != null)
            {
                var imageBuffer = BitmapSourceToByteArray((BitmapSource)imageControltest.Source);
                querystring = $"INSERT INTO Questions(QuestionText, Photo,TestsID) VALUES('{question}', '{imageBuffer}', '{testID}')";
            }
            _dataBase.openConnection();
            SqlCommand cmd = new SqlCommand(querystring, _dataBase.getConnection());
            cmd.ExecuteNonQuery();
            _dataBase.closeConnection();
        }

        private void db_test_Answers()
        {
            var AnswersOne = txtAwnserOne.Text;
            var AnswersTwo = txtAwnserTwo.Text;
            var AnswersTree = txtAwnserTree.Text;
            var AnswersFour = txtAwnserFour.Text;
            var questName = txt.Text;
            int questionID;
            bool isCorrect = false;
            _dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystringTest = $"select ID from Questions where QuestionText = '{questName}' ";
            SqlCommand command = new SqlCommand(querystringTest, _dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    questionID = reader.GetInt32(0);
                }
                else
                {
                    questionID = -1;
                }
            }

            string querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{questName}', '{questionID}', '{isCorrect}')";

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        if ((bool)myCheckBoxAwnserOne.IsChecked == true)
                        {
                            isCorrect = true;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersOne}', '{questionID}', '{isCorrect}')";
                        }
                        else
                        {
                            isCorrect = false;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersOne}', '{questionID}', '{isCorrect}')";
                        }
                        break;
                    case 1:
                        if ((bool)myCheckBoxAwnserTwo.IsChecked == true)
                        {
                            isCorrect = true;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersTwo}', '{questionID}', '{isCorrect}')";
                        }
                        else
                        {
                            isCorrect = false;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersTwo}', '{questionID}', '{isCorrect}')";
                        }
                        break;
                    case 2:
                        if ((bool)myCheckBoxAwnserTree.IsChecked == true)
                        {
                            isCorrect = true;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersTree}', '{questionID}', '{isCorrect}')";

                        }
                        else
                        {
                            isCorrect = false;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersTree}', '{questionID}', '{isCorrect}')";
                        }
                        break;
                    case 3:
                        if ((bool)myCheckBoxAwnserFour.IsChecked == true)
                        {
                            isCorrect = true;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersFour}', '{questionID}', '{isCorrect}')";

                        }
                        else
                        {
                            isCorrect = false;
                            querystring = $"INSERT INTO Answers(AnswerText, QuestionsID, IsCorrect) VALUES('{AnswersFour}', '{questionID}', '{isCorrect}')";
                        }
                        break;
                }
                SqlCommand cmd = new SqlCommand(querystring, _dataBase.getConnection());
                cmd.ExecuteNonQuery();
            }
            _dataBase.closeConnection();
        }


        private void Button_Click_NewQuestion(object sender, RoutedEventArgs e)
        {
            number += 1;
            string questionBox = "Вопрос №" + number.ToString();
            question.Text = questionBox;
            db_test();
            db_test_Answers();
            txt.Text = "текст вопроса";
            txt.Foreground = Brushes.LightGray;
            imageControltest.Source = null;
            buttonImageTest.IsEnabled = false;
            imageControltest.Visibility = Visibility.Collapsed;
            txtAwnserOne.Text = "";
            txtAwnserTwo.Text = "";
            txtAwnserTree.Text = "";
            txtAwnserFour.Text = "";
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            TestBild testBild = new TestBild();
            testBild.Show();
            this.Close();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
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
            string querystringDelete = $"delete from Tests where ID = '{TestID}' ";
            SqlCommand cmd = new SqlCommand(querystringDelete, _dataBase.getConnection());
            cmd.ExecuteNonQuery();
            _dataBase.closeConnection();

            AdminMain main = new AdminMain();
            main.Show();
            this.Close();
        }
    }
}
