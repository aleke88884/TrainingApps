namespace AlbertSessionSecondApi.DTO
{
    public class RequestedItemDto
    {
        public int RequestedItemId { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; } = null!;
        public string EventName { get; set; } = null!;

        public int Amount { get; set; }

        public bool IsFull { get; set; }

        // Дополнительно, если нужно показать информацию о бронировании:
        public int ReservationCount { get; set; }

        public List<ReservationDTO>? Reservations { get; set; }
    }
}
