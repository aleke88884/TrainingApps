using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlbertSession2Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        private readonly int userId = 0;
        public MainTabbedPage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadEvents();
            LoadOffers();
            LoadRequests();
        }

        private void refreshButton_Clicked(object sender, EventArgs e)
        {
            EventsCollectionView.ItemsSource = null;
            OffersCollectionView.ItemsSource = null;
            RequestsCollectionView.ItemsSource = null;
            LoadEvents();
            LoadOffers();
            LoadRequests();
        }
        private async void LoadEvents()
        {
            var events = await ApiService.LoadEvents(userId);
            var futureEvents = events.ToList();
            EventsCollectionView.ItemsSource = futureEvents;

        }

        private async void LoadOffers()
        {
            var offers = await ApiService.LoadOffers(userId);
            var futureOffers = offers.ToList();
            OffersCollectionView.ItemsSource = futureOffers;
        }

        private async void LoadRequests()
        {
            var requests = await ApiService.LoadRequests();
            var futureRequests = requests.ToList();
            RequestsCollectionView.ItemsSource = futureRequests;
        }
    }
}