using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlbertSession2Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

     
       

        private async void  btnLogin_Clicked(object sender, EventArgs e)
        {
            var result = await ApiService.Login(emailEntry.Text, passwordEntry.Text);

            if (result.Success)
            {
                await App.Current.MainPage.DisplayAlert("Success", result.Message, "OK");
                Application.Current.MainPage = new MainTabbedPage(result.userId ?? 0);
            }
            else
            {
                await DisplayAlert("Error", result.Message, "OK");
            }
        }
    }
}
