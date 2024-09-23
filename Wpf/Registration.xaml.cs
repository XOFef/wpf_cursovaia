﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Wpf
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
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

    }
}
