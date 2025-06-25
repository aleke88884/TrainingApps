using Newtonsoft.Json;
using System.Collections.Generic;

namespace AlbertSessionSecondApi.DTO
{
    public class OfferDto
    {
        public int offerId { get; set; }
        public int userId { get; set; }
        public int? requestId { get; set; }
        public int Amount { get; set; }
        public string requestedItemName { get; set; } = "";
        private List<ReservationDTO> _reservations = new List<ReservationDTO>();

        [JsonProperty("reservations")]
        public List<ReservationDTO> reservations
        {
            get => _reservations;
            set => _reservations = value ?? new List<ReservationDTO>();
        }
    }
}
