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


namespace Wpf
{
    public partial class TestBild : Window
    {
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

        // Функция для открытия обзора файлов
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
        // Кнопка для выбора изображения
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                OpenImageFileDialog();
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
        // Кнопка для выбора изображения
        private void Button_Click_Test(object sender, RoutedEventArgs e)
        {
            OpenImageFileDialogTest();
        }
        // Кнопка для очистки
        private void Button_Click_clear(object sender, RoutedEventArgs e)
        {
           txt.Clear();
           txt.Text = "текст вопроса";
           txt.Foreground = Brushes.LightGray;
        }
        // Взаимодействие с текстбокс (когда фокус)
        private void MyTextBox_GotFocus_Awnser(object sender, RoutedEventArgs e)
        {
            if (txtAwnser.Text == "Текст ответа")
            {
                txtAwnser.Text = "";
                txtAwnser.Foreground = Brushes.Black; // Меняем цвет текста на черный при фокусе
            }
        }
        // Взаимодействие с текстбокс (когда нет фокуса)
        private void MyTextBox_LostFocus_Awnser(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAwnser.Text))
            {
                txtAwnser.Text = "Текст ответа";
                txtAwnser.Foreground = Brushes.LightGray; // Возвращаем светло-серый цвет
            }
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
        // Кнопка для выбора изображения
        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            OpenImageFileDialogResult();
        }

    }
}
