using AlbertSessionFour.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlbertSessionFour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketPage : ContentPage
    {
        private EventDto selectedEvent;
        private decimal total = 0;
        public TicketPage(EventDto eventDto)
        {
            InitializeComponent();
            selectedEvent = eventDto;

            EventNameLabel.Text = selectedEvent.Name;
            EventVenueLabel.Text = $"Venue: {selectedEvent.Location}";
            EventStartLabel.Text = $"Start: {selectedEvent.Start}";
            EventEndLabel.Text = $"End: {selectedEvent.End}";
            EventPriceLabel.Text = $"Price: {selectedEvent.Price:C}";

            TicketCountEntry.TextChanged += TicketCountEntry_TextChanged;
        }

        private void TicketCountEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TicketCountEntry.Text, out int count) && count >= 0)
            {
                total = selectedEvent.Price * count;
                TotalPriceLabel.Text = $"Total: {total:C}";
            }
            else
            {
                TotalPriceLabel.Text = "Total: -";
            }
        }

        private bool ValidateCreditCard()
        {
            if (CardTypePicker.SelectedIndex == -1) return false;
            if (CardNumberEntry.Text?.Length != 16 || !CardNumberEntry.Text.All(char.IsDigit)) return false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(CardExpiryEntry.Text ?? "", @"^(0[1-9]|1[0-2])\/\d{2}$")) return false;
            if (CardCheckEntry.Text?.Length != 3 || !CardCheckEntry.Text.All(char.IsDigit)) return false;

            return true;
        }

        private string GenerateTicketNumber(string eventName)
        {
            string cleaned = eventName.ToUpper().PadRight(5);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                char c = cleaned[i];
                if (c == ' ')
                {
                    builder.Append("00");
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    int code = c - 'A' + 1;
                    builder.Append(code.ToString("D2"));
                }
                else
                {
                    builder.Append("00");
                }
            }

            string random = new Random().Next(100000, 999999).ToString();
            return builder.ToString() + random;
        }

        private async void PurchaseButton_Clicked(object sender, EventArgs e)
        {
            if (!ValidateCreditCard())
            {
                await DisplayAlert("Error", "Please fill in valid credit card data.", "OK");
                return;
            }

            if (!int.TryParse(TicketCountEntry.Text, out int count) || count <= 0)
            {
                await DisplayAlert("Error", "Please enter a valid number of tickets.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirm", "Do you really want to complete the purchase?", "Yes", "No");
            if (!confirm) return;

            string ticketNumber = GenerateTicketNumber(selectedEvent.Name);
            
            var ticket = new TicketDto
            {
                TicketNr = ticketNumber,
                Event = new EventDto
                {
                   Name = selectedEvent.Name,
                    Location = selectedEvent.Location,
                    Start = selectedEvent.Start,
                    End = selectedEvent.End,
                },
                
                Persons = int.Parse(TicketCountEntry.Text),
                TotalPrice = total,
                
            };
            if (int.TryParse(PersonsNumber.Text, out int persons))
            {
                ticket.Persons = persons;
            }
            string ticketText = $"Ticket No: {ticket.TicketNr}\nEvent: {ticket.Event.Name}\nVenue: {ticket.Event.Name}\nStart: {ticket.Event.Start}\nPrice: {total:C}\nTickets: {TicketCountEntry.Text}";
            await DisplayAlert("Your Ticket", ticketText, "OK");


            var request = new AddTicketRequest
            {
                TicketNr = ticket.TicketNr,
                EventId = selectedEvent.EventId,
                UserId = 1, 
                TotalPrice = total,
                Persons = ticket.Persons
            };

            var api = new ApiService();
            await Navigation.PushAsync(new CalendarPage(selectedEvent));

            
// Возврат к Event List
        }
    }
}
