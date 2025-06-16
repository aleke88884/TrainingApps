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

namespace AlbertSession2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Password.ToString()))
            {
                MessageBox.Show("Please fill in both fields!");
                return;
            }

            var db = DB.Gt();

            var user = db.Users.FirstOrDefault(a => a.username == usernameTextBox.Text);

            if (user == null)
            {
                MessageBox.Show("User not found!");
                return;
            }

            if (!PasswordHelper.verifyPassword(passwordTextBox.Password.ToString(), user.password_hash))
            {
                MessageBox.Show("Incorrect password!");
                return;
            }
            else
            {
                MessageBox.Show("Login successfully!");
            }


        }
    }
}
