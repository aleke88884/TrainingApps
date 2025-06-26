using AlbertSessionFour.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlbertSessionFour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailsPage : ContentPage
    {
        private EventDto selectedEvent;
        public EventDetailsPage(EventDto e)
        {
            InitializeComponent();
            selectedEvent = e;
            LoadEventDetail();
        }

        private async void LoadEventDetail()
        {
            NameLabel.Text = selectedEvent.Name;
            LocationLabel.Text = $"📍 {selectedEvent.Location}";
            StartLabel.Text = $"🕒 Start: {selectedEvent.Start:dd.MM.yyyy HH:mm}";
            EndLabel.Text = $"⏳ End: {selectedEvent.End:dd.MM.yyyy HH:mm}";
            PriceLabel.Text = $"💰 Price: {selectedEvent.Price} ₸";

            ProgramPointsCollectionView.ItemsSource = selectedEvent.ProgramPoints;
            foreach (var picture in selectedEvent.Pictures)
            {
                // Убеждаемся, что путь — это встраиваемый файл из drawable
                picture.Picture1 = picture.Picture1?.ToLowerInvariant(); // "a.jpg"
            }
            PicturesCollectionView.ItemsSource = selectedEvent.Pictures;
            await DisplayAlert("Pictures", $"{selectedEvent.Pictures.Count }", "Ok");
        }
        private async void BtnSaveCalendar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Saved to calendar", "Successfully saved to database", "Ok");

        }

        private async void BtnBuyTicket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketPage(selectedEvent));
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}