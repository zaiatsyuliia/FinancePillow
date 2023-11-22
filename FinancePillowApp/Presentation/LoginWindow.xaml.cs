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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Logic.Login(LoginEmailTextBox.Text, LoginPasswordBox.Password))
            {
                UserData.userId = Logic.GetUserId(LoginEmailTextBox.Text);
                this.Hide();
                MainWindow MainWindow = new();
                MainWindow.Show();
            }
            else
            {
                MessageBox.Show("Incorrect login credentials. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //ДОДАТИ ПЕРЕВІРКУ ПАРОЛЯ І ЕМЕЙЛА
            if (Logic.R
                (RegisterNicknameTextBox.Text, RegisterPasswordBox.Password, RegisterEmailTextBox.Text))
            {

                UserData.userId = Logic.GetUserId(RegisterEmailTextBox.Text);
                this.Hide();
                MainWindow MainWindow = new();
                MainWindow.Show();
            }
            else
            {
                MessageBox.Show("Email already exists. Please change email.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "E-mail" || textBox.Text == "Password" || textBox.Text == "Username")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }


        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name.Contains("Email") ? "E-mail" : textBox.Name.Contains("Password") ? "Password" : "Username";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
                passwordBox.Password = "";
                passwordBox.Foreground = Brushes.Black;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            passwordBox.Foreground = Brushes.Gray;
            
        }
    }
}
