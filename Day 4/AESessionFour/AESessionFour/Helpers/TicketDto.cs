namespace AESessionFourApi.Helpers
{
    public class TicketDto
    {
        public string TicketNr { get; set; } = null!;

        public int EventId { get; set; }

        public int UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Persons { get; set; }

        public EventDto Event { get; set; }
        
    }
}
