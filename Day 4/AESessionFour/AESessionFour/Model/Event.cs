using System;
using System.Collections.Generic;

namespace AESessionFourApi.Model;

public partial class Event
{
    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();

    public virtual ICollection<ProgramPoint> ProgramPoints { get; set; } = new List<ProgramPoint>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
