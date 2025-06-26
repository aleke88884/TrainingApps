using System;
using System.Collections.Generic;

namespace AESessionFourApi.Model;

public partial class Ticket
{
    public string TicketNr { get; set; } = null!;

    public int EventId { get; set; }

    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public int Persons { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
