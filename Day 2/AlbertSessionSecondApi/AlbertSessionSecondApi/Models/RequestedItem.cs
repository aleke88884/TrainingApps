using System;
using System.Collections.Generic;

namespace AlbertSessionSecondApi.Models;

public partial class RequestedItem
{
    public int RequestedItemId { get; set; }

    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
