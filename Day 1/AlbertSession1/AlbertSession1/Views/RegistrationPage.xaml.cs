using AlbertSession1.Models;
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
    /// Логика взаимодействия для RegistrationScreeen.xaml
    /// </summary>
    public partial class RegistrationScreeen : Page
    {
        public RegistrationScreeen()
        {
            InitializeComponent();
        }

        private void RegisterBtnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text) ||
        string.IsNullOrWhiteSpace(passwordBOx.Text) ||
        string.IsNullOrWhiteSpace(preNameBox.Text) ||
        string.IsNullOrWhiteSpace(familyNameBox.Text) ||
        string.IsNullOrWhiteSpace(postalcodeAndTownBox.Text) ||
        string.IsNullOrWhiteSpace(addressBox.Text) ||
        string.IsNullOrWhiteSpace(phoneBox.Text) ||
        string.IsNullOrWhiteSpace(hobbyBox.Text) ||
        birthDayPicker.SelectedDate == null)
            {
                resultText.Text = "Please fill in all the fields!";
                return;
            }

            try
            {
                DB.SignUpUser(
                    emailTextBox.Text,
                    passwordBOx.Text,
                    preNameBox.Text,
                    familyNameBox.Text,
                    postalcodeAndTownBox.Text,
                    birthDayPicker.SelectedDate.Value,
                    addressBox.Text,
                    phoneBox.Text,
                    hobbyBox.Text
                );

                resultText.Foreground = Brushes.Green;
                resultText.Text = "Registration successful!";
            }
            catch (Exception ex)
            {
                resultText.Foreground = Brushes.Red;
                resultText.Text = $"Registration failed: {ex.Message}";
            }
        }
    }
}
