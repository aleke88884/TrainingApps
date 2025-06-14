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
    /// Логика взаимодействия для ModeratorScreen.xaml
    /// </summary>
    public partial class ModeratorScreen : Page
    {
        public ModeratorScreen()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = DB.getAllUsers();
            InReviewEventsGrid.ItemsSource = DB.getAllEvents();


        }

        private void ReviewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUnban_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (sender as FrameworkElement)?.DataContext as ContentUser;
            if (selectedUser != null)
            {
                DB.userBanChange(!selectedUser.isBanned, selectedUser.email);
            }
            UsersDataGrid.ItemsSource = DB.getAllUsers();
        }

        private void ApproveBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedEvent = (sender as FrameworkElement)?.DataContext as @event;
            if(selectedEvent != null)
            {
                var dbEvent = DB.Gt().@event.FirstOrDefault(a => a.id == selectedEvent.id);
                dbEvent.state = "approved";
                MessageBox.Show("Approved!");
                DB.Gt().SaveChanges();
            }
        }

        private void RejectBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedEvent = (sender as FrameworkElement)?.DataContext as @event;
            if (selectedEvent != null)
            {
                var dbEvent = DB.Gt().@event.FirstOrDefault(a => a.id == selectedEvent.id);
               if(rejectionCommentBox.Text== string.Empty)
                {
                    MessageBox.Show("Please fill the reject comment!");
                    return;
                }
                dbEvent.state = "rejected";
                MessageBox.Show("Rejected!");
                DB.Gt().SaveChanges();
            }
        }

        private void BanOrganizerBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = DB.Gt();
            var selectedEvent = (sender as FrameworkElement)?.DataContext as @event;
            if (selectedEvent != null)
            {
                var dbEvent = db.@event.FirstOrDefault(a => a.id == selectedEvent.id);
                string email = dbEvent.organizer;
                var dbUser = db.users.FirstOrDefault(a => a.email == email);
                if (dbUser != null)
                {
                    dbUser.IsBanned = true;
                    MessageBox.Show("Organizer was Banned!");

                }
                else
                {
                    MessageBox.Show("User was not found!");
                }
            }
            db.SaveChanges();
        }

        private void InReviewEventsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEvent = InReviewEventsGrid.SelectedItem as @event;

            if (selectedEvent != null)
            {
                eventNameText.Text = $"Event Name: {selectedEvent.name}";
                eventVenueText.Text = $"Venue Name: {selectedEvent.venue.name}";
                eventDatesText.Text = $"Start Date: {selectedEvent.start}  --  End Date: {selectedEvent.end}";
                eventStatusText.Text = $"Event State: {selectedEvent.state}";
                organizerEmailText.Text = $"Event Organizer Email: {selectedEvent.organizer}";
            }

             
        }

        private void btnAddModerator_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
