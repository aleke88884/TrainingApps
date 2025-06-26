using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSessionFour.Helper
{
    public class TicketDto
    {
        public string TicketNr { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Persons { get; set; }

        public EventDto Event { get; set; }

    }
}
