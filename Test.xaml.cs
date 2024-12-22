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
    public class Question
    {
        public byte[] Photo { get; set; }
        public string QuestionText { get; set; }

    }
    public class Answer
    {
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }

    }
    public partial class Test : Window
    {
        DataBase _dataBase = new DataBase();
        private List<Question> questions;
        private List<Answer> answers;
        private int currentQuestionIndex;
        private int currentQuestionIndexTwo;
        private bool isCorrectOne;
        private bool isCorrectTwo;
        private bool isCorrectTree;
        private bool isCorrectFour;
        private int Score;
        public Test()
        {
            InitializeComponent();
            LoadQuestions();
            currentQuestionIndex = 0;
            currentQuestionIndexTwo = 0;
            DisplayCurrentQuestion(); 
            Loadanswers();
            DisplayCurrentAnswers();
        }

        private List<Question> GetTestById(int TestId)
        {
            List<Question> question = new List<Question>();
            _dataBase.openConnection();
            string query = "SELECT QuestionText, Photo FROM Questions WHERE TestsID = @ID";

                using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
                {
                    command.Parameters.AddWithValue("@ID", TestId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Нет данных для указанного пользователя.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Question questions = new Question
                                {
                                    Photo = reader["Photo"] as byte[], 
                                    QuestionText = reader["QuestionText"].ToString(),
                                   
                                };
                                question.Add(questions);
                            } 
                        }
                    }
                }
                _dataBase.closeConnection();
            return question; 
        }

        private void db()
        {
            var currentQuestion = questions[currentQuestionIndexTwo];
            Application.Current.Properties["IDQuestion"] = currentQuestion.QuestionText;
            currentQuestionIndexTwo += 1;
        }
        private int db_IDQuestion()
        {
            int db_ID = 0;
            db();
            _dataBase.openConnection();
            string query = "SELECT ID FROM Questions WHERE QuestionText = @QuestionText";

            using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@QuestionText", Application.Current.Properties["IDQuestion"]?.ToString() ?? string.Empty);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        db_ID = Convert.ToInt32(reader["ID"]);
                    }
                }
            }
            _dataBase.closeConnection();
            return db_ID;
        }

        private List<Answer> db_IDAnswer() 
        {
            List<Answer> answer = new List<Answer>();
            _dataBase.openConnection();
            string query = "SELECT AnswerText, IsCorrect FROM Answers WHERE QuestionsID = @ID";

            using (SqlCommand command = new SqlCommand(query, _dataBase.getConnection()))
            {
                command.Parameters.AddWithValue("@ID", db_IDQuestion());
                _dataBase.openConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Нет данных для указанного пользователя.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Answer answers = new Answer
                            {
                                IsCorrect = (bool)reader["IsCorrect"],
                                AnswerText = reader["AnswerText"].ToString(),

                            };
                            answer.Add(answers);
                        }
                    }
                }
            }
            _dataBase.closeConnection();
            return answer;
        }

   

        private void LoadQuestions()
        {
            questions = GetTestById((int)Application.Current.Properties["ID"]); 
        }
        private void DisplayCurrentQuestion()
        {
            if (questions != null && questions.Count > 0)
            {
                var currentQuestion = questions[currentQuestionIndex];
                Title.Text = currentQuestion.QuestionText;

                // Загрузка изображения из массива байтов
                if (currentQuestion.Photo != null && currentQuestion.Photo.Length > 0)
                {
                    TestPhoto.Source = ByteArrayToBitmapImage(currentQuestion.Photo);
                }
                else
                {
                    TestPhoto.Source = null;  // Скрыть изображение, если его нет
                }
            }
            else
            {
                Title.Text = "Нет вопросов для отображения.";
                TestPhoto.Source = null;// Скрыть изображение
            }
        }

        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (questions != null && currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayCurrentQuestion();
                Loadanswers();
                DisplayCurrentAnswers();
                myCheckBoxAwnserOne.IsChecked = false;
                myCheckBoxAwnserTwo.IsChecked = false;
                myCheckBoxAwnserTree.IsChecked = false;
                myCheckBoxAwnserFour.IsChecked = false;
            }
            else
            {
                Score--;
                MessageBox.Show($"Это последний вопрос. Ваш счет: '{Score}'");
                Application.Current.Properties["Score"] = Score;
                Result result = new Result();
                result.Show();
                this.Close();
            }
        }
        private BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // Загружаем изображение сразу
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                bitmap.Freeze(); // Замораживаем объект, чтобы его можно было использовать в разных потоках
                return bitmap;
            }
        }



        private void Loadanswers()
        {
            answers = db_IDAnswer();
        }
        private void DisplayCurrentAnswers()
        {
            if (questions != null && questions.Count > 0)
            {
                int i = 0;
                var currentAnwersIndex = answers[i];
                txtAwnserOne.Text = currentAnwersIndex.AnswerText;
                i += 1;
                currentAnwersIndex = answers[i];
                txtAwnserTwo.Text = currentAnwersIndex.AnswerText;
                i += 1;
                currentAnwersIndex = answers[i];
                txtAwnserTree.Text = currentAnwersIndex.AnswerText;
                i += 1;
                currentAnwersIndex = answers[i];
                txtAwnserFour.Text = currentAnwersIndex.AnswerText;
                i = 0;
                currentAnwersIndex = answers[i];
                isCorrectOne = currentAnwersIndex.IsCorrect;
                i += 1;
                currentAnwersIndex = answers[i];
                isCorrectTwo = currentAnwersIndex.IsCorrect;
                i += 1;
                currentAnwersIndex = answers[i];
                isCorrectTree = currentAnwersIndex.IsCorrect;
                i += 1;
                currentAnwersIndex = answers[i];
                isCorrectFour = currentAnwersIndex.IsCorrect;
                answers.Clear();


            }
        }



        private void myCheckBox_Checked_One(object sender, RoutedEventArgs e)
        {
            if (isCorrectOne == true )
            {
                Score+=2;
            }
        }
        private void myCheckBox_Checked_Two(object sender, RoutedEventArgs e)
        {
            if (isCorrectTwo == true)
            {
                Score += 2;
            }
        }
        private void myCheckBox_Checked_Tree(object sender, RoutedEventArgs e)
        {
            if (isCorrectTree == true)
            {
                Score += 2;
            }
        }
        private void myCheckBox_Checked_Four(object sender, RoutedEventArgs e)
        {
            if (isCorrectFour == true)
            {
                Score += 2;
            }
        }

        private void myCheckBox_Unchecked_One(object sender, RoutedEventArgs e)
        {
            if (isCorrectOne == true)
            {
                Score--;
            }
        }
        private void myCheckBox_Unchecked_Two(object sender, RoutedEventArgs e)
        {
            if (isCorrectTwo == true)
            {
                Score--;
            }
        }
        private void myCheckBox_Unchecked_Tree(object sender, RoutedEventArgs e)
        {
            if (isCorrectTree == true)
            {
                Score--;
            }
        }
        private void myCheckBox_Unchecked_Four(object sender, RoutedEventArgs e)
        {
            if (isCorrectFour == true)
            {
                Score--;
            }
        }
    }
}
