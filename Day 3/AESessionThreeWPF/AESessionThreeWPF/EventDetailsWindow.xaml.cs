using AESessionThreeWPF.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AESessionThreeWPF
{
    /// <summary>
    /// Interaction logic for EventDetailsWindow.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        private EventTableItem _eventItem;

        public EventDetailsWindow(EventTableItem eventItem)
        {
            InitializeComponent();
            _eventItem = eventItem;
            LoadEventDetails();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOptimize_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LoadEventDetails()
        {
            EventNameTxt.Text = _eventItem.name;
            var eventData = DB.GT().Events.FirstOrDefault(ev => ev.Name == _eventItem.name);
            var tierItems = eventData.Tickets
                .GroupBy(t => t.TicketTier)
                .Select(gr => new TiersTableItem { 
                        name = gr.Key?.Name ?? "Unknown",
                        saleability = gr.Key?.Tickets.Count(t => !t.Bookings.Any()) ?? 0,
                        demand = gr.Key?.Tickets.Count(t => t.Bookings.Any()) ?? 0,
                        price = (int)Math.Round(gr.Average(t=> t.ActualPrice ?? 0)),
                        basePrice = (int)Math.Round(gr.Key?.BasePrice ?? 0),
                        available = gr.Key?.Tickets.Count(t => !t.Bookings.Any()) ?? 0,
                        max = gr.Sum(t=>t.MaxAvailable ?? 0)

                }).ToList();

            TiersDataGrid.ItemsSource = tierItems;
            if (eventData != null)
            {
                var availableTickets = eventData.Tickets.Count(t => !t.Bookings.Any());
                var soldTickets = eventData.Tickets.Count(t => t.Bookings.Any());
                var profitLoss = eventData.Organizer != null ? (eventData.Cost * eventData.BaseDemand) - eventData.Cost : 0;


                string formattedProfitLoss = profitLoss?.ToString("+#0.00;-#0.00");

                CostTxt.Text = $"Cost: ${eventData.Cost}";
                ProfitLostTxt.Text = $"Profit/Lost: ${formattedProfitLoss}";
                SoldTicketsTxt.Text = $"Sold Tickets: {soldTickets}";
                AvailableTicketsTxt.Text = $"Available Tickets: {availableTickets}";
            }

            var forecastItems = CalculateTierForecast(eventData);
            TierForecastDataGrid.ItemsSource = forecastItems;

            DrawForecastChart();
        }

        private List<TierForecastItem> CalculateTierForecast(Event even)
        {
            var tiers = even.Tickets
                .GroupBy(t => t.TicketTier)
                .Where(g => g.Key != null)
                .Select(f =>
                {
                    var tier = f.Key;
                    var total = f.Count();
                    var sold = f.Count(t => t.Bookings.Any());
                    var basePrice = tier.BasePrice ?? 0;
                    var available = total - sold;

                    double demand = total > 0 ? (double)sold / total : 0;
                    double saleability = demand * 100;
                    return new
                    {
                        name = tier.Name,
                        sold,
                        available,
                        basePrice = (int)Math.Round(basePrice),
                        saleability = (int)Math.Round(saleability),
                    };
                }).ToList();
            var result = new List<TierForecastItem>();

            foreach(var tier in tiers)
            {
                result.Add(new TierForecastItem
                {
                    name = tier.name,
                    amount = tier.sold,
                    price = tier.basePrice,
                    saleability = tier.saleability,
                    isForecast = false

                });
            }

            if(even.StartsAt > DateTime.Now)
            {
                var availableMap = tiers.ToDictionary(t => t.name, t => t.available);
                var saleabilityMap = tiers.ToDictionary(t => t.name, t => t.saleability);
                var priceMap = tiers.ToDictionary(t => t.name, t => t.basePrice);

                while (availableMap.Values.Sum() > 0)
                {
                    var bestTier = availableMap
                        .Where(kv => kv.Value > 0)
                        .OrderByDescending(kv => saleabilityMap[kv.Key])
                        .FirstOrDefault().Key;

                    if (bestTier == null)
                    {
                        break;
                    }

                    availableMap[bestTier]--;

                    var forecastItem = result.FirstOrDefault(r => r.name == bestTier && r.isForecast);
                    if (forecastItem != null)
                    {
                        forecastItem.amount += 1;
                    }
                    else
                    {
                        result.Add(new TierForecastItem
                        {
                            name = bestTier,
                            amount = 1,
                            price = priceMap[bestTier],
                            saleability = saleabilityMap[bestTier],
                            isForecast = true
                        });
                    }

                }
               
            }
            return result;
        }

        private void DrawForecastChart()
        {
            var actualPoints = new List<ChartPoint>
    {
        new ChartPoint { Index = 1, Price = 10, Label = "Actual" },
        new ChartPoint { Index = 2, Price = 12, Label = "Actual" },
        new ChartPoint { Index = 3, Price = 15, Label = "Actual" }
    };

            var forecastPoints = new List<ChartPoint>
    {
        new ChartPoint { Index = 4, Price = 16, Label = "Forecast" },
        new ChartPoint { Index = 5, Price = 18, Label = "Forecast" },
        new ChartPoint { Index = 6, Price = 21, Label = "Forecast" }
    };

            LineChart.Series.Clear();

            // Style for Actual
            var actualLineStyle = new Style(typeof(Polyline));
            actualLineStyle.Setters.Add(new Setter(Shape.StrokeProperty, Brushes.ForestGreen));
            actualLineStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, 2.5));

            // Style for Forecast
            var forecastLineStyle = new Style(typeof(Polyline));
            forecastLineStyle.Setters.Add(new Setter(Shape.StrokeProperty, Brushes.DarkViolet));
            forecastLineStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, 2.5));
            forecastLineStyle.Setters.Add(new Setter(Shape.StrokeDashArrayProperty, new DoubleCollection { 3, 2 }));

            // No markers
            var noMarkerStyle = new Style(typeof(Control));
            noMarkerStyle.Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate()));

            var actualSeries = new LineSeries
            {
                Title = "Actual",
                DependentValuePath = "Price",
                IndependentValuePath = "Index",
                ItemsSource = actualPoints,
                PolylineStyle = actualLineStyle,
                DataPointStyle = noMarkerStyle
            };

            var forecastSeries = new LineSeries
            {
                Title = "Forecast",
                DependentValuePath = "Price",
                IndependentValuePath = "Index",
                ItemsSource = forecastPoints,
                PolylineStyle = forecastLineStyle,
                DataPointStyle = noMarkerStyle
            };

            LineChart.Series.Add(actualSeries);
            LineChart.Series.Add(forecastSeries);
        }



    }
}
