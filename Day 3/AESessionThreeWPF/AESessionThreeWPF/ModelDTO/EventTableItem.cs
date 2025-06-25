using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESessionThreeWPF.ModelDTO
{
    public class EventTableItem
    {
        public string name { get; set; }
        public int availableTickets { get; set; }
        public int soldTickets { get; set; }
        public int allTickets { get; set; }
        public double occupancy { get; set; }
        public DateTime eventDate { get; set; }
    }
}
