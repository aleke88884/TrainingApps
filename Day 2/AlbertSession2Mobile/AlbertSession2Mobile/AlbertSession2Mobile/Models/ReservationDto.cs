using System;

namespace AlbertSessionSecondApi.DTO
{
    public class ReservationDTO
    {
        public int reservationId { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public string reservedByUsername { get; set; } = "";
    }
}
