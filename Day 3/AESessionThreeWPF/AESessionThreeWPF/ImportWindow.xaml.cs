using AESessionThreeWPF.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;


namespace AESessionThreeWPF
{
    /// <summary>
    /// Interaction logic for ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        string selectedType = string.Empty;

        string selectedFileType = "All files (*.*)|*.*";
        albertSessionThreeEntities1 db = new albertSessionThreeEntities1(); 
        public ImportWindow()
        {
            InitializeComponent();
        }

        private string _filePath; // глобальная переменная, чтобы использовать потом в импорте

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            // Определение типа и фильтра — у тебя уже правильно написано:
            if (RbOrganizers.IsChecked == true)
            {
                selectedType = "Organizers";
                selectedFileType = "JSON files (*.json)|*.json";
            }
            else if (RbLocations.IsChecked == true)
            {
                selectedType = "Locations";
                selectedFileType = "TOML files (*.toml)|*.toml";
            }
            else if (RbEvents.IsChecked == true)
            {
                selectedType = "Events";
                selectedFileType = "CSV files (*.csv)|*.csv";
            }
            else if (RbBookingsCsv.IsChecked == true)
            {
                selectedType = "BookingsCsv";
                selectedFileType = "CSV files (*.csv)|*.csv";
            }
            else if (RbBookingsMc.IsChecked == true)
            {
                selectedType = "BookingsMc";
                selectedFileType = "Mc files (*.mc)|*.mc";
            }
            else if (RbBookingsTpc.IsChecked == true)
            {
                selectedType = "BookingsTpc";
                selectedFileType = "Tpc files (*.tpc)|*.tpc";
            }
            else
            {
                selectedFileType = "All files (*.*)|*.*";
            }

            // Открытие файла
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
                        var organizersJson = File.ReadAllText(_filePath);
                        var organizers = JsonSerializer.Deserialize<List<OrganizerDto>>(organizersJson);
                        foreach (var item in organizers)
                        {
                            db.Organizers.Add(new Organizer { 
                            Id = item.id,
                            Name = item.name,
                            Address = item.address
                            
                            
                            });
                            
                        }
                        db.SaveChanges();
                        break;
                    case "Locations":
                        var tomlText = File.ReadAllText(_filePath);
                        var tomlModel = Tomlyn.Toml.ToModel(tomlText);

                        var locations = new List<LocationDto>();
                        var locationTableToArray= tomlModel["bookings"] as Tomlyn.Model.TomlTableArray;
                        foreach (var table in locationTableToArray)
                        {
                            var location = new LocationDto
                            {
                                id = table["id"]?.ToString(),
                                name = table["name"]?.ToString(),
                                location = table["location"]?.ToString(),
                                maxvisitors = Convert.ToInt32(table["max_visitors"]),
                                description = table["description"]?.ToString()
                            };
                            db.Locations.Add(new Location
                            {
                                Id = location.id,
                                Name = location.name,
                                Location1 = location.location,
                                MaxVisitors = location.maxvisitors,
                                Description = location.description,
                            });
                            }
                        db.SaveChanges();
                        break;
                    case "Events":
                        var eventsJson = File.ReadAllText(_filePath);
                        var events = new List<EventDto>();
                        using (var reader = new StreamReader(_filePath))
                        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                        {
                            var eventDtos = csv.GetRecords<EventDto>().ToList();
                            events = eventDtos;
                        }
                       foreach (var item in events)
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
                        break;
                    case "BookingsCsv":
                        var bookings = new List<BookingDto>();
                        using (var reader = new StreamReader(_filePath))
                        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                        {
                            var bookingsCsv = csv.GetRecords<BookingDto>().ToList();
                            bookings = bookingsCsv;
                        }
                        foreach (var item in bookings)
                        {
                            db.Bookings.Add(new Booking {
                                

                                Id = item.id,
                                UserId = item.userId,
                                TicketId = item.ticketId,
                                BoughtAt = (DateTime)item.boughtAt,
                                Amount = item.amount,
                                Price = item.price,




                            });
                        }
                        db.SaveChanges();
                        break;
                    case "BookingsMc":
                        var mcLines = File.ReadAllLines(_filePath);
                        var bookingsMc = mcLines.Select(ParseMcLine).ToList();
                          foreach (var item in bookingsMc)
                        {
                            db.Bookings.Add(new Booking {
                                

                                Id = item.id,
                                UserId = item.userId,
                                TicketId = item.ticketId,
                                BoughtAt = (DateTime)item.boughtAt,
                                Amount = item.amount,
                                Price = item.price,




                            });
                        }
                        db.SaveChanges();// Метод ParseMcLine напишем ниже
                        break;

                    case "BookingsTpc":
                        var tpcLines = File.ReadAllLines(_filePath);
                        var bookingsTpc = tpcLines.Select(ParseTpcLine).ToList(); // Аналогично
                        foreach (var item in bookingsTpc)
                        {
                            db.Bookings.Add(new Booking
                            {


                                Id = item.id,
                                UserId = item.userId,
                                TicketId = item.ticketId,
                                BoughtAt = (DateTime)item.boughtAt,
                                Amount = item.amount,
                                Price = item.price,




                            });
                        }
                        db.SaveChanges();

                        break;

                    default:
                        MessageBox.Show("Unknown type selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during import: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


        }
        private BookingDto ParseMcLine(string line)
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


        private BookingDto ParseTpcLine(string line)
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
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }

        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            EventDetailsWindow eventDetailsWindow = new EventDetailsWindow();
            eventDetailsWindow.Show();
            this.Close();
        }
    }
    }

