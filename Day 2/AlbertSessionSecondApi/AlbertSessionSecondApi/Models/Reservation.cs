using System;
using System.Collections.Generic;

namespace AlbertSessionSecondApi.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? RequestId { get; set; }

    public int? OfferId { get; set; }

    public int? ReservedByUserId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Offer? Offer { get; set; }

    public virtual RequestedItem? Request { get; set; }

    public virtual User? ReservedByUser { get; set; }
}
