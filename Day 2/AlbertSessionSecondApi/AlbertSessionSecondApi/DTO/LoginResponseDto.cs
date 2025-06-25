namespace AlbertSessionSecondApi.DTO
{
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public int? userId { get; set; }
        public string? Message { get; set; }
    }
}
