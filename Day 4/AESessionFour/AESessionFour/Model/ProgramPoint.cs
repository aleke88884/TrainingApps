using System;
using System.Collections.Generic;

namespace AESessionFourApi.Model;

public partial class ProgramPoint
{
    public int ProgramPointId { get; set; }

    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public virtual Event Event { get; set; } = null!;
}
