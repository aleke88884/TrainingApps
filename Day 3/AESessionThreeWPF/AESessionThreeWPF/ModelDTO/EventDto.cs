using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESessionThreeWPF.ModelDTO
{
    public class EventDto
    {
        public string id { get; set; }
        public string organizerId { get; set; }
        public string locationId { get; set; }
        public string eventGroupId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public TimeSpan? duration { get; set; }
        public decimal? baseDemand { get; set; }
        public decimal? cost { get; set; }
        public string hosts { get; set; }
        // Navigation properties can be added if needed
    }
}
