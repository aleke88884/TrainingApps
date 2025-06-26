using AlbertSessionFour.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlbertSessionFour
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            var result = await ApiService.Login(usernameEntry.Text, passwordEntry.Text);
            if (result.Success)
            {
                await App.Current.MainPage.DisplayAlert("Success", result.Message, "OK");
                await Navigation.PushAsync(new EventListPage());
            }
            else
            {
                await DisplayAlert("Error", result.Message, "OK");

            }
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {

        }
    }
}
