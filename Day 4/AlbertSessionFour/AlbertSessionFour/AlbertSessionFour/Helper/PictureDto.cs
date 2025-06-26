using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSessionFour.Helper
{
    public class PictureDto
    {
        public int PictureId { get; set; }

        public int EventId { get; set; }

        public string Picture1 { get; set; }
        public EventDto Event { get; set; }
    }
}
