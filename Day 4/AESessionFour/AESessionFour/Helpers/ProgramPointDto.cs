namespace AESessionFourApi.Helpers
{
    public class ProgramPointDto
    {
        public int ProgramPointId { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; } = null!;

        public int Order { get; set; }
        public EventDto Event { get; set; }
    }
}
