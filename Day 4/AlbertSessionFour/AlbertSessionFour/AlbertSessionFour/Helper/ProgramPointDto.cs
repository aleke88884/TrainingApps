using System;
using System.Collections.Generic;
using System.Text;

namespace AlbertSessionFour.Helper
{
    public class ProgramPointDto
    {
        public int ProgramPointId { get; set; }

        public int EventId { get; set; }

        public string Name { get; set; } 

        public int Order { get; set; }
        public EventDto Event { get; set; }
    }
}
