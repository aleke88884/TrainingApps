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

namespace AlbertSession2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int userId;

        public MainWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            // Теперь можно использовать userId сразу, например:
            LoadUserEvents();
        }
        private void LoadUserEvents()
        {
            EventsDataGrid.ItemsSource = DB.Gt().Events
                .Include("Locations")
                .Include("Users")
                .Where(e => e.user_id == userId)
                .ToList();
        }
        private void LoadOffers()
        {
            var offers = DB.Gt().Offers.Include("Users").Include("RequestedItems").Include("Reservations");

        }
    }
}
