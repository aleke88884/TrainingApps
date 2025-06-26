namespace AESessionFourApi.Helpers
{
    public class AddTicketRequest
    {
        public string TicketNr { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int Persons { get; set; }
    }
}
