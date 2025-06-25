using AlbertSession2Mobile.Models;
using AlbertSessionSecondApi.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlbertSession2Mobile
{
    public class ApiService
    {
        public static string BaseUrl = "http://10.0.2.2:8002/api";
        private static HttpClient client = new HttpClient();
        public static async Task<LoginResponseDto> Login(string username, string password)
        {
       
            var url = $"{BaseUrl}/Auth/login";

            var loginData = new
            {
                username = username,
                password = password
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            
            try
            {
                var response = await client.PostAsync(url, content);
                
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponseDto>(responseBody);
                
            }
            catch(HttpRequestException ex)
            {
                return new LoginResponseDto { Success = false,Message = $"Request failed: {ex.Message}",
                    userId = null
                };
            }
           

        } 
        public static async Task<List<EventDto>> LoadEvents(int userId)
        {
            var url = $"{BaseUrl}/Events/getEvents/{userId}";
            try
            {
                var response = await client.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventDto>>(responseBody);
            }catch(HttpRequestException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error loading data: " + ex.Message, "OK");
                return new List<EventDto>();
            }
        }

        public static async Task<List<OfferDto>> LoadOffers(int userId)
        {
            var url = $"{BaseUrl}/Offer/getOffer/{userId}";
            try
            {
                var response = await client.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                var offers = JsonConvert.DeserializeObject<List<OfferDto>>(responseBody);
            

                foreach (var offer in offers)
                {
                    if (offer.reservations == null)
                        offer.reservations = new List<ReservationDTO>();
                    else
                        offer.reservations = offer.reservations
                            .Where(r => r != null) // ⚠️ удаляет null-элементы
                            .ToList();

                    if (offer.requestedItemName == null)
                        offer.requestedItemName = "";
                }
                return offers;
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error loading data: " + ex.Message, "OK");
                return new List<OfferDto>();
            }
        }
        public static async Task<List<RequestedItemDto>> LoadRequests() { 
            var url = $"{BaseUrl}/Request/getRequests";
            try
            {
                var response = await client.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                var requests= JsonConvert.DeserializeObject<List<RequestedItemDto>>(responseBody);
                await Application.Current.MainPage.DisplayAlert("DEBUG", responseBody, "OK");

                foreach (var request in requests)
                {
                    if (request.Reservations == null)
                        request.Reservations = new List<ReservationDTO>();
                    
                        

                    
                }
                return requests;
            }
            catch (HttpRequestException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error loading data: " + ex.Message, "OK");
                return new List<RequestedItemDto>();
            }
        }
    }
}
