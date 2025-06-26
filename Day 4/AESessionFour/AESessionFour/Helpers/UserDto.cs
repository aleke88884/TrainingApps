namespace AESessionFourApi.Helpers
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public List<TicketDto> Tickets { get; set; }
    }
}
