namespace AESessionFourApi.Helpers
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal Price { get; set; }
        public List<PictureDto> Pictures { get; set; }
        public List<ProgramPointDto> ProgramPoints {  get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}
