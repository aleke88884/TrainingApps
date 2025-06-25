using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSession2Mobile.Models
{
    public class EventDto
    {
        public int eventId { get; set; }
        public int userId { get; set; }
        public int locationId { get; set; }
        public string name { get; set; } = "";
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string locationName { get; set; }
        public List<RequestedItemDto> requestedItems { get; set; } = new List<RequestedItemDto>();
    }
}
