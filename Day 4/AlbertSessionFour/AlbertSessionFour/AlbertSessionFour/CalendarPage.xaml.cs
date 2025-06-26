using AlbertSessionFour.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace AlbertSessionFour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        private List<EventDto> events = new List<EventDto>();
        public CalendarPage(EventDto eventDto)
        {
            InitializeComponent();
            events.Add(eventDto);
            GetEvents();
        }
        private async void GetEvents()
        {
            events = await ApiService.GetEventsAsync();

            foreach (var e in events)
            {
                var date = e.Start.Date;
                bool isBooked = e.Tickets != null && e.Tickets.Count > 0;

                EventCalendar.SpecialDates.Add(new SpecialDate(date)
                {
                    BackgroundColor = isBooked ? Color.Blue : Color.Green,
                    TextColor = Color.White,
                    Selectable = true
                });
            }
        }

        private void EventCalendar_DateClicked_1(object sender, DateTimeEventArgs e)
        {
            DateTime date = e.DateTime;

            SelectedDateLabel.Text = $"Events on {date:dd.MM.yyyy}";

            var eventsOnThisDay = events
                .Where(ev => ev.Start.Date == date.Date)
                .Select(ev => new
                {
                    Name = ev.Name,
                    Venue = ev.Location,
                    StartAt = ev.Start.ToString("HH:mm"),
                    TicketInfo = (ev.Tickets != null && ev.Tickets.Count > 0)
                        ? $"Booked ({ev.Tickets.Count} ticket(s))"
                        : "Not booked"
                })
                .ToList();

            DayEventsListView.ItemsSource = eventsOnThisDay;
        }

    }
}