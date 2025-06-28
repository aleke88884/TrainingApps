using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace AlbertSessionFive
{
    public partial class MainWindow : Window
    {
        private ApiService apiService;
        private Dictionary<(int, int), Seat> seatMap = new Dictionary<(int, int), Seat>();
        private ObservableCollection<string> logEntries = new ObservableCollection<string>();
        private List<Seat> cart = new List<Seat>();
        private List<Seat> selectedSeats = new List<Seat>();
        private Event currentEvent;

        public MainWindow()
        {
            InitializeComponent();

            // Подключаем список мероприятий и лог
            var context = new albertFiveEntities();
            EventSelector.ItemsSource = context.Events.ToList();
            // Если в вашем классе свойство называется Name — укажите DisplayMemberPath="Name"
            EventSelector.DisplayMemberPath = "name";
            EventSelector.SelectedValuePath = "event_id";
            LogListBox.ItemsSource = logEntries;

            // Изначально кнопки отключены
            AddToCartButton.IsEnabled = false;
            CheckoutButton.IsEnabled = false;
        }

        private void EventSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentEvent = EventSelector.SelectedItem as Event;
            if (currentEvent == null) return;

            // Отключаем старый ApiService
            if (apiService != null)
            {
                apiService.SeatStateChanged -= ApiService_SeatStateChanged;
                apiService.Disconnect();
            }

            // Создаём новый, подписываемся на обновления и шлём event_id
            apiService = new ApiService();
            apiService.SeatStateChanged += ApiService_SeatStateChanged;
            if (apiService.Connect())
            {
                apiService.SendEventId((short)currentEvent.event_id);
                apiService.StartListening();
            }

            // Загружаем сетку мест и сбрасываем корзину/лог
            LoadSeatsFromDatabase(currentEvent);
            cart.Clear();
            logEntries.Clear();
            UpdateCartDisplay();
            ShowSeatDetails();
        }

        private void LoadSeatsFromDatabase(Event ev)
        {
            SeatGrid.Children.Clear();
            SeatGrid.RowDefinitions.Clear();
            SeatGrid.ColumnDefinitions.Clear();
            seatMap.Clear();
            selectedSeats.Clear();
            SelectedSeatText.Text = "";

            var loc = ev.Location;
            int rows = loc.rows;
            int cols = loc.seats_per_row;

            var vGaps = loc.Gaps.Where(g => g.Direction.name == "vertical")
                                .Select(g => g.position).ToHashSet();
            var hGaps = loc.Gaps.Where(g => g.Direction.name == "horizontal")
                                .Select(g => g.position).ToHashSet();
            var unavailable = loc.UnavailableSeats
                                .Select(u => (u.row, u.seat)).ToHashSet();

            // создаём нужное число Row/ColumnDefinition, включая промежутки
            for (int r = 0; r < rows + hGaps.Count; r++)
                SeatGrid.RowDefinitions.Add(new RowDefinition());
            for (int c = 0; c < cols + vGaps.Count; c++)
                SeatGrid.ColumnDefinitions.Add(new ColumnDefinition());

            int displayRow = 0;
            for (int r = 0; r < rows; r++)
            {
                if (hGaps.Contains(r)) { displayRow++; continue; }

                int displayCol = 0;
                for (int c = 0; c < cols; c++)
                {
                    if (vGaps.Contains(c)) { displayCol++; continue; }
                    if (unavailable.Contains((r, c))) { displayCol++; continue; }

                    var seat = new Seat
                    {
                        Row = r,
                        Column = c,
                        State = SeatState.Empty,
                        Price = (double)ev.price
                    };
                    seatMap[(r, c)] = seat;

                    var btn = CreateSeatButton(seat);
                    Grid.SetRow(btn, displayRow);
                    Grid.SetColumn(btn, displayCol);
                    SeatGrid.Children.Add(btn);

                    displayCol++;
                }
                displayRow++;
            }
        }

        private Button CreateSeatButton(Seat seat)
        {
            var btn = new Button
            {
                Width = 30,
                Height = 30,
                Margin = new Thickness(2),
                Tag = seat,
                Background = GetSeatBrush(seat.State),
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(1)
            };
            btn.Click += SeatButton_Click;
            return btn;
        }

        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var seat = (Seat)btn.Tag;
            if (seat.State != SeatState.Empty) return; // нельзя выбирать занятое

            if (selectedSeats.Contains(seat))
            {
                selectedSeats.Remove(seat);
                btn.BorderBrush = Brushes.Transparent;
            }
            else
            {
                selectedSeats.Add(seat);
                btn.BorderBrush = Brushes.Blue;
                btn.BorderThickness = new Thickness(3);
            }

            ShowSeatDetails();
        }

        private void ShowSeatDetails()
        {
            // Если ничего не выбрано — текст пустой и AddToCart отключена
            if (selectedSeats.Count == 0)
            {
                SelectedSeatText.Text = "";
                AddToCartButton.IsEnabled = false;
            }
            else
            {
                // Показываем либо детали одного места, либо количество
                if (selectedSeats.Count == 1)
                {
                    var s = selectedSeats[0];
                    SelectedSeatText.Text =
                      $"ряд {s.Row + 1}, место {s.Column + 1} — {GetDiscountedPrice(currentEvent, (decimal)s.Price):0.00}";
                }
                else
                {
                    SelectedSeatText.Text =
                      $"выбрано мест: {selectedSeats.Count}";
                }
                // AddToCart активируется только если все выбранные места свободны и ещё не в корзине
                AddToCartButton.IsEnabled = selectedSeats.All(s => s.State == SeatState.Empty)
                                          && selectedSeats.All(s => !cart.Contains(s));
            }

            // Кнопка Buy активна, когда в корзине есть хотя бы одно место
            CheckoutButton.IsEnabled = cart.Count > 0;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var s in selectedSeats.ToList())
            {
                cart.Add(s);
                // помечаем его цветом «в корзине»
                var btn = SeatGrid.Children
                            .OfType<Button>()
                            .First(b => ((Seat)b.Tag) == s);
                btn.Background = Brushes.LightGreen;
                btn.BorderBrush = Brushes.Transparent;
            }
            selectedSeats.Clear();
            SelectedSeatText.Text = "";

            UpdateCartDisplay();
            ShowSeatDetails();
        }

        private void UpdateCartDisplay()
        {
            // Формируем коллекцию для биндинга
            var items = cart.Select(s => new {
                Seat = s,
                DisplayText = $"ряд {s.Row + 1}, место {s.Column + 1} — {GetDiscountedPrice(currentEvent, (decimal)s.Price):0.00}"
            }).ToList();

            CartListBox.ItemsSource = items;
            CartSummaryText.Text =
              $"в корзине: {cart.Count} мест — на сумму {cart.Sum(s => GetDiscountedPrice(currentEvent, (decimal)s.Price)):0.00}";
        }

        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var seat = (Seat)btn.Tag;
            cart.Remove(seat);

            // возвращаем кнопке её исходный цвет
            var seatBtn = SeatGrid.Children
                            .OfType<Button>()
                            .First(b => ((Seat)b.Tag) == seat);
            seatBtn.Background = GetSeatBrush(seat.State);

            UpdateCartDisplay();
            ShowSeatDetails();
        }

        private void ClearCart_Click(object sender, RoutedEventArgs e)
        {
            foreach (var s in cart)
            {
                var btn = SeatGrid.Children
                            .OfType<Button>()
                            .First(b => ((Seat)b.Tag) == s);
                btn.Background = Brushes.LightGray;
            }
            cart.Clear();
            UpdateCartDisplay();
            ShowSeatDetails();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var s in cart)
                apiService.SendSeatOccupied((short)s.Row, (short)s.Column);

            cart.Clear();
            UpdateCartDisplay();
            ShowSeatDetails();
        }

        private void ApiService_SeatStateChanged(object sender, SeatStateChangedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var key = (e.Row, e.Column);
                if (!seatMap.TryGetValue(key, out var seat)) return;

                seat.State = (SeatState)e.State;
                var btn = SeatGrid.Children
                            .OfType<Button>()
                            .First(b => ((Seat)b.Tag) == seat);
                btn.Background = GetSeatBrush(seat.State);

                // добавляем в лог (с +1 чтобы было человеческое счёт от 1)
                logEntries.Insert(0,
                  $"{seat.State}: ряд {seat.Row + 1}, место {seat.Column + 1}");
            });
        }

        private Brush GetSeatBrush(SeatState state)
        {
            switch (state)
            {
                case SeatState.Empty:
                    return Brushes.LightGray;
                case SeatState.Bought:
                    return Brushes.Orange;
                case SeatState.Occupied:
                    return Brushes.Red;
                default:
                    return Brushes.Gray;
            }
        }

        private double GetDiscountedPrice(Event ev, decimal basePrice)
        {
            double price = (double)basePrice;
            if (DateTime.Now >= ev.start)
                price -= price * (ev.discount_percent / 100.0);
            return price;
        }

        private void LogListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LogListBox.SelectedItem is string entry)) return;
            var parts = entry.Split(':')[1].Split(',');
            int r = int.Parse(parts[0].Replace("ряд", "").Trim()) - 1;
            int c = int.Parse(parts[1].Replace("место", "").Trim()) - 1;

            if (!seatMap.TryGetValue((r, c), out var seat)) return;
            var btn = SeatGrid.Children
                        .OfType<Button>()
                        .First(b => ((Seat)b.Tag) == seat);
            btn.BringIntoView();
            // переиспользуем логику клика
            SeatButton_Click(btn, null);
        }
    }
}
