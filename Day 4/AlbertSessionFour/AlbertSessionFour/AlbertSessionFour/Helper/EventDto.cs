using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSessionFour.Helper
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string Name { get; set; } 

        public string Location { get; set; } 

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal Price { get; set; }
        public List<PictureDto> Pictures { get; set; }
        public List<ProgramPointDto> ProgramPoints { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
