using AESessionThreeWPF.ModelDTO;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using Tomlyn;

namespace AESessionThreeWPF
{
    public partial class ImportWindow : Window
    {
        private string selectedType = string.Empty;
        private string selectedFileType = "All files (*.*)|*.*";
        private string _filePath;
        private readonly albertSessionThreeEntities1 db = new albertSessionThreeEntities1();

        public ImportWindow() => InitializeComponent();

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (RbOrganizers.IsChecked == true)
                SetFileType("Organizers", "JSON files (*.json)|*.json");
            else if (RbLocations.IsChecked == true)
                SetFileType("Locations", "TOML files (*.toml)|*.toml");
            else if (RbEvents.IsChecked == true)
                SetFileType("Events", "CSV files (*.csv)|*.csv");
            else if (RbBookingsCsv.IsChecked == true)
                SetFileType("BookingsCsv", "CSV files (*.csv)|*.csv");
            else if (RbBookingsMc.IsChecked == true)
                SetFileType("BookingsMc", "Mc files (*.mc)|*.mc");
            else if (RbBookingsTpc.IsChecked == true)
                SetFileType("BookingsTpc", "Tpc files (*.tpc)|*.tpc");

            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = selectedFileType,
                Title = $"Select a {selectedType} file"
            };

            if (dialog.ShowDialog() == true)
            {
                _filePath = dialog.FileName;
                MessageBox.Show($"Selected file:\n{_filePath}", "File selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No file selected.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SetFileType(string type, string filter)
        {
            selectedType = type;
            selectedFileType = filter;
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath) || string.IsNullOrEmpty(selectedType))
            {
                MessageBox.Show("Please select a file and type before importing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                switch (selectedType)
                {
                    case "Organizers":
                        ImportOrganizers();
                        break;
                    case "Locations":
                        ImportLocations();
                        break;
                    case "Events":
                        ImportEvents();
                        break;
                    case "BookingsCsv":
                        ImportBookingsFromCsv();
                        break;
                    case "BookingsMc":
                        ImportBookingsFromLines(File.ReadAllLines(_filePath), ParseMcLine);
                        break;
                    case "BookingsTpc":
                        ImportBookingsFromLines(File.ReadAllLines(_filePath), ParseTpcLine);
                        break;
                    default:
                        MessageBox.Show("Unknown type selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during import:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImportOrganizers()
        {
            var json = File.ReadAllText(_filePath);
            var organizers = JsonSerializer.Deserialize<List<OrganizerDto>>(json);
            foreach (var item in organizers)
            {
                db.Organizers.Add(new Organizer
                {
                    Id = item.id,
                    Name = item.name,
                    Address = item.address
                });
            }
            db.SaveChanges();
        }

        private void ImportLocations()
        {
            var toml = Toml.ToModel(File.ReadAllText(_filePath));
            var tables = toml["bookings"] as Tomlyn.Model.TomlTableArray;

            foreach (var table in tables)
            {
                db.Locations.Add(new Location
                {
                    Id = table["id"]?.ToString(),
                    Name = table["name"]?.ToString(),
                    Location1 = table["location"]?.ToString(),
                    MaxVisitors = Convert.ToInt32(table["max_visitors"]),
                    Description = table["description"]?.ToString()
                });
            }
            db.SaveChanges();
        }

        private void ImportEvents()
        {
             var reader = new StreamReader(_filePath);
            var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            var records = csv.GetRecords<EventDto>().ToList();

            foreach (var item in records)
            {
                db.Events.Add(new Event
                {
                    Id = item.id,
                    Name = item.name,
                    Description = item.description,
                    StartsAt = (DateTime)item.startsAt,
                    LocationId = item.locationId,
                    OrganizerId = item.organizerId
                });
            }
            db.SaveChanges();
        }

        private void ImportBookingsFromCsv()
        {
            var reader = new StreamReader(_filePath);
            var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            var records = csv.GetRecords<BookingDto>().ToList();
            SaveBookings(records);
        }

        private void ImportBookingsFromLines(string[] lines, Func<string, BookingDto> parser)
        {
            var records = lines.Select(parser).ToList();
            SaveBookings(records);
        }

        private void SaveBookings(IEnumerable<BookingDto> bookings)
        {
            foreach (var item in bookings)
            {
                db.Bookings.Add(new Booking
                {
                    Id = item.id,
                    UserId = item.userId,
                    TicketId = item.ticketId,
                    BoughtAt = (DateTime)item.boughtAt,
                    Amount = item.amount,
                    Price = item.price
                });
            }
            db.SaveChanges();
        }

        private BookingDto ParseMcLine(string line) => ParseDelimitedBooking(line);
        private BookingDto ParseTpcLine(string line) => ParseDelimitedBooking(line);

        private BookingDto ParseDelimitedBooking(string line)
        {
            var parts = line.Split(',');
            return new BookingDto
            {
                id = parts[0],
                userId = parts[1],
                ticketId = parts[2],
                boughtAt = DateTime.Parse(parts[3]),
                amount = int.Parse(parts[4]),
                price = decimal.Parse(parts[5])
            };
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            new DashboardWindow().Show();
            Close();
        }

        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            // To be implemented if needed
        }
    }
}
