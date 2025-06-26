using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlbertSessionFour.Helper
{
    public class ApiService
    {
        public static string BaseUrl = "http://10.0.2.2:8004/api/Home";
        private static HttpClient client = new HttpClient();



        public static async Task<List<EventDto>> GetEventsAsync(string name = null, string location = null, DateTime? start = null) {
            var url = new StringBuilder($"{BaseUrl}/getEvents");
            var hasQuery = false;

            if (!string.IsNullOrWhiteSpace(name))
            {
                url.Append(hasQuery ? "&" : "?");
                url.Append($"name={Uri.EscapeDataString(name)}");
                hasQuery = true;
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                url.Append(hasQuery ? "&" : "?");
                url.Append($"location={Uri.EscapeDataString(location)}");
                hasQuery = true;
            }

            if (start.HasValue)
            {
                url.Append(hasQuery ? "&" : "?");
                url.Append($"start={start.Value:yyyy-MM-dd}");
                hasQuery = true;
            }


            try
            {
                var response = await client.GetAsync(url.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EventDto>>(json);
            }catch(Exception ex)
            {
                return null;
            }
        }



        public async Task<bool> AddTicketAsync(AddTicketRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{BaseUrl}/addTicket", content);

            return response.IsSuccessStatusCode;
        }


        public static async Task<LoginResponseDto> Login(string username, string password)
        {
            var url = $"{BaseUrl}/login";
            var loginData = new
            {
                username = username,
                password = password,
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResponseDto>(responseBody);
            }
            catch (Exception ex)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = $"Request failed: {ex.Message}"
                };
            }
        }
    }

}
