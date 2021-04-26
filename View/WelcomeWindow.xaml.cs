using PasswordManager.Animations;
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
using PasswordManager.Properties;
using Newtonsoft.Json;
using PasswordManager.Data.Classes;
using System.IO;
using System.Reflection;

namespace PasswordManager.View
{
    /// <summary>
    /// Логика взаимодействия для WelcomeForm.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SmoothAppearanceAnimation animation = new SmoothAppearanceAnimation(welcomeGrid, nextButton);
            SmoothAppearanceAnimationText animationText = new SmoothAppearanceAnimationText(infoLabel, welcomeLabel);
            animation.SetAnimationPropertiesAndBegin(2, 2, 100, 10);
            animationText.SetAnimationPropertiesAndBegin(2, 100, 10);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            welcomeLabel.Opacity = 0.01;
            welcomeGrid.Opacity = 0.01;
            infoLabel.Opacity = 0.01;
            nextButton.Opacity = 0.01;
            welcomeGrid.Width = 250;
            welcomeGrid.Height = 114;
            nextButton.Width = 72;
            nextButton.Height = 18;
            welcomeLabel.FontSize = 12;
            infoLabel.FontSize = 8;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!PasswordFormatCheck(passwordTextBox.Text))
            {
                MessageBox.Show("Неправильный формат пароля, попробуйте еще раз", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                passwordTextBox.Clear();
            }
            MasterPassword ms = new MasterPassword();
            ms.Hash = passwordTextBox.Text;
            ms.Length = passwordTextBox.Text.Length;
            ms.Safe = true;
            string serialized = JsonConvert.SerializeObject(ms);
            DataWriter dw = new DataWriter(serialized, "master_password.json");
            dw.WriteAsync();
        }

        private bool PasswordFormatCheck(string arg)
        {
            if (arg.Length < Password.MAX_PASSWORD_LENGTH && arg.Length >= Password.MIN_PASSWORD_LENGTH)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (passwordTextBox.Text == "")
            {
                passwordCorrectCheckLabel.Content = "";
            }
            PasswordSafe safe = new PasswordSafe(passwordTextBox.Text);
            if (PasswordFormatCheck(passwordTextBox.Text))
            {
                switch(safe.CheckAll()) {
                    case PasswordSafe.SafePower.Bad:
                        passwordCorrectCheckLabel.Foreground = new SolidColorBrush(Colors.Red);
                        passwordCorrectCheckLabel.Content = "Не безопасный пароль";
                        break;
                    case PasswordSafe.SafePower.Normal:
                        passwordCorrectCheckLabel.Foreground = new SolidColorBrush(Colors.Orange);
                        passwordCorrectCheckLabel.Content = "Умеренный пароль";
                        break;
                    case PasswordSafe.SafePower.Good:
                        passwordCorrectCheckLabel.Foreground = new SolidColorBrush(Colors.YellowGreen);
                        passwordCorrectCheckLabel.Content = "Безопасный пароль";
                        break;
                    case PasswordSafe.SafePower.Excelent:
                        passwordCorrectCheckLabel.Foreground = new SolidColorBrush(Colors.Green);
                        passwordCorrectCheckLabel.Content = "Очень безопасный пароль";
                        break;
                }

            }
            else
            {
                passwordCorrectCheckLabel.Foreground = new SolidColorBrush(Colors.Red);
                passwordCorrectCheckLabel.Content = "Пароль не может быть меньше 4 или больше 100 символов";
            }
        }
    }
}

