using AlbertSession1.Models;
using AlbertSession1.Services;
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

namespace AlbertSession1
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Page
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string loginText = emailTextBox.Text;
            string passwordText = passwordBox.Password.ToString();

            if (loginText == string.Empty || passwordText == string.Empty)
            {
                errorText.Text =
                    "Please fill the fields";
            }
            else
            {
                errorText.Text =
                            "";


            }


            bool isModerator = false;
            string result = "";
            if (DB.LoginUser(loginText, passwordText, out isModerator, out result))
            {
                if (isModerator)
                {
                    Navigation.Frame.Navigate(new ModeratorScreen());
                }
                else
                {
                    Navigation.Frame.Navigate(new EventOrganizerScreen());

                }
            }
            else
            {
                errorText.Text = result;
            }
            
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Frame.Navigate(new RegistrationScreeen());
        }
    }
}
