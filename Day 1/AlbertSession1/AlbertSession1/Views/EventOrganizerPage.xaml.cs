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
    /// Логика взаимодействия для EventOrganizerScreen.xaml
    /// </summary>
    public partial class EventOrganizerScreen : Page
    {
        public EventOrganizerScreen()
        {
            InitializeComponent();
            EventDataGrid.ItemsSource = DB.getEventsWithVenue();
            
        }


        

        private void PreviewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createEventBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string filterText = SearchBox.Text.ToLower();
            string selectedStatus = (StatusFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(filterText) && (selectedStatus == "All" || string.IsNullOrEmpty(selectedStatus)))
            {
              
                EventDataGrid.ItemsSource = DB.getEventsWithVenue();
                return;
            }

            var allEvents = DB.getEventsWithVenue();

            var filteredItems = allEvents.Where(item =>
                (string.IsNullOrEmpty(filterText) || item.name.ToLower().Contains(filterText)) &&
                (selectedStatus == "All" ||
 item.state.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            EventDataGrid.ItemsSource = filteredItems;
        }


        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            

        }
    }
}
