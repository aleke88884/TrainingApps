namespace AlbertSessionSecondApi.DTO
{
    public class OfferDto
    {
        public int offerId { get; set; }
        public int userId { get; set; }
        public int? requestId { get; set; }
        public string? requestedItemName { get; set; } = null!;
        public int Amount { get; set; }
        public List<ReservationDTO> reservations { get; set; } = new ();
    }
}
