using AESessionThreeWPF.ModelDTO;
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
using Xceed.Wpf.AvalonDock.Controls;

namespace AESessionThreeWPF
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            ComboboxEventGroup.ItemsSource = DB.GT().EventGroups.Select(a => a.Name).ToList();
            var tableEvents = DB.GT().Events.Select(ev => new EventTableItem
            {
                name = ev.Name,
                availableTickets = ev.Tickets.Count(t=> !t.Bookings.Any()),
                soldTickets = ev.Tickets.Count(t => t.Bookings.Any()),
                allTickets = ev.Tickets.Count(),
                occupancy = ev.Tickets.Count() == 0 ? 0:
                Math.Round((double)ev.Tickets.Count(t=> t.Bookings.Any())/ev.Tickets.Count()*100,2),
                eventDate = ev.StartsAt,
            }).ToList();

            EventsDataGrid.ItemsSource = tableEvents;
        }

        private void ComboboxEventGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGroup = ComboboxEventGroup.SelectedItem as string;

            var events = DB.GT().Events
                .Where(ev => ev.EventGroup.Name == selectedGroup)
                .ToList();

            var tickets = DB.GT().Tickets.ToList();


            var bookings = DB.GT().Bookings.ToList();

            var totalCost = events.Sum(ev => ev.Cost);
            var totalIncome = events.Sum(ev => ev.Cost * ev.BaseDemand); // Estimation based on demand

            var differencePercent = (totalIncome - totalCost) / totalCost * 100;
            string formattedDifference = differencePercent?.ToString("+#0.00;-#0.00") + "%";

            int numberOfEvents = events.Count;
            int upcomingEvents = events.Count(ev => ev.StartsAt > DateTime.Now);

            string leastProfitableEvent = events.OrderBy(ev => (ev.Cost * ev.BaseDemand) - ev.Cost).FirstOrDefault()?.Name ?? "N/A";
            string mostProfitableEvent = events.OrderBy(ev => (ev.Cost * ev.BaseDemand) - ev.Cost).LastOrDefault()?.Name ?? "N/A";

            

            var averageIncome = totalIncome / numberOfEvents;
            var averageProfit = (totalIncome - totalCost) / numberOfEvents;
            var averageOccupancyRate = (double)upcomingEvents / numberOfEvents * 100;
            var averageTicketPrice = tickets.Sum(t => t.ActualPrice) / tickets.Count;

            var soldTickets = bookings.Sum(b => b.Amount);
            var availableTickets = tickets.Sum(t => t.MaxAvailable);
            var cheapestTicketPrice = tickets.Min(t => t.ActualPrice);
            var mostExpensiveTicketPrice = tickets.Max(t => t.ActualPrice);



            TotalCostTxt.Text = $"Total Cost: $ {totalCost:F2}";
            TotalIncomeTxt.Text = $"Total Income: $ {totalIncome:F2}";
            DifferenceTxt.Text = $"Difference: {formattedDifference}";

            LeastProfitableTxt.Text = $"Least profitable: {leastProfitableEvent}";
            MostProfitableTxt.Text = $"Most profitable: {mostProfitableEvent}";
            NumberOfEventsTxt.Text = $"Number of events: {numberOfEvents}";
            UpcomingEventsTxt.Text = $"Upcoming events: {upcomingEvents}";

            AverageIncomeTxt.Text = $"Average Income: ${averageIncome:F1}";
            AverageProfitTxt.Text = $"Average Profit: ${averageProfit:F1}";
            AverageOccupancyTxt.Text = $"Average Occupancy Rate: {averageOccupancyRate:F2}%";
            AverageTicketPriceTxt.Text = $"Average Ticket Price: ${averageTicketPrice:F2}";


            SoldTicketsTxt.Text = $"Sold Tickets: {soldTickets}";
            AvailableTicketsTxt.Text = $"Available Tickets: {availableTickets}";
            CheapestTicketTxt.Text = $"Cheapest Ticket: ${cheapestTicketPrice:F2}";
            MostExpensiveTicketTxt.Text = $"Most Expensive Ticket: ${mostExpensiveTicketPrice:F2}";

        }

        private void RBShowPastEvents_Checked(object sender, RoutedEventArgs e)
        {
            EventsDataGrid.Items.Clear();
            var tableEvents = DB.GT().Events.Where(ev => ev.StartsAt < DateTime.Now)
                .Select(ev => new EventTableItem {
                    name = ev.Name,
                    availableTickets = ev.Tickets.Count(t => !t.Bookings.Any()),
                    soldTickets = ev.Tickets.Count(t => t.Bookings.Any()),
                    allTickets = ev.Tickets.Count(),
                    occupancy = ev.Tickets.Count() == 0 ? 0: 
                    Math.Round((double) ev.Tickets.Count(t=>t.Bookings.Any())/ev.Tickets.Count()*100,2),
                    eventDate = ev.StartsAt,
                
                }).ToList();

            EventsDataGrid.ItemsSource = tableEvents;
        }

        private void RBShowPastEvents_Unchecked(object sender, RoutedEventArgs e)
        {
            EventsDataGrid.Items.Clear();
            var tableEvents = DB.GT().Events.Select(ev => new EventTableItem
            {
                name = ev.Name,
                availableTickets = ev.Tickets.Count(t => !t.Bookings.Any()),
                soldTickets = ev.Tickets.Count(t => t.Bookings.Any()),
                allTickets = ev.Tickets.Count(),
                occupancy = ev.Tickets.Count() == 0 ? 0 :
                            Math.Round((double)ev.Tickets.Count(t => t.Bookings.Any()) / ev.Tickets.Count() * 100, 2),
                eventDate = ev.StartsAt,
            }).ToList();

            EventsDataGrid.ItemsSource = tableEvents;
        }

        private void EventsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EventsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = EventsDataGrid.SelectedItem as EventTableItem;

            if (selectedItem != null)
            {
                var eventDetailsWindow = new EventDetailsWindow(selectedItem);
                eventDetailsWindow.DataContext = selectedItem;
                eventDetailsWindow.ShowDialog();
            }
        }
    }
}
