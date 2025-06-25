using AlbertSessionSecondApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSession2Mobile.Models
{
    public class RequestedItemDto
    {
        public int RequestedItemId { get; set; }

        public int EventId { get; set; }
        public string EventName { get; set; }

        public string Name { get; set; } = "";

        public int Amount { get; set; }

        public bool IsFull { get; set; }

        // Дополнительно, если нужно показать информацию о бронировании:
        public int ReservationCount { get; set; }

        public List<ReservationDTO> Reservations { get; set; }
    }
}
