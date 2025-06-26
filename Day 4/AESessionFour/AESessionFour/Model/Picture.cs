using System;
using System.Collections.Generic;

namespace AESessionFourApi.Model;

public partial class Picture
{
    public int PictureId { get; set; }

    public int EventId { get; set; }

    public string Picture1 { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;
}
