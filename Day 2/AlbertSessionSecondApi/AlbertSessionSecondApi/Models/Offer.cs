using System;
using System.Collections.Generic;

namespace AlbertSessionSecondApi.Models;

public partial class Offer
{
    public int OfferId { get; set; }

    public int? UserId { get; set; }

    public int? RequestId { get; set; }

    public virtual RequestedItem? Request { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User? User { get; set; }
}
