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
    public partial class EventListPage : ContentPage
    {
        public EventListPage()
        {
            InitializeComponent();
            LoadEvents();
        }
        private async void LoadEvents(string name = null,string location = null,string start = null)
        {
            DateTime? startDate = null;
            if (!string.IsNullOrWhiteSpace(start))
            {
                if(DateTime.TryParse(start,out DateTime parsedDate))
                {
                    startDate = parsedDate;
                }
                else
                {
                    await DisplayAlert("Error", "Incorrect date entry format: Use YYYY-MM-DD.", "OK");
                }
            }
            var events = await ApiService.GetEventsAsync(name, location,startDate);
            EventListView.ItemsSource = events;
        }
        private void btnSearch_Clicked(object sender, EventArgs e)
        {
            LoadEvents(NameFilterEntry.Text, VenueFilterEntry.Text, DateFilterEntry.Text);
        }

        private async void EventListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var selectedItem = e.SelectedItem as EventDto;

            if (selectedItem == null) return;

            await Navigation.PushAsync(new EventDetailsPage(selectedItem));
                
        }

        private async void OpenCalendarButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}