namespace AESessionFourApi.Helpers
{
    public class PictureDto
    {
        public int PictureId { get; set; }

        public int EventId { get; set; }

        public string Picture1 { get; set; } = null!;
        public EventDto Event { get; set; }
    }
}
