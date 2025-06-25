using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESessionThreeWPF.ModelDTO
{
    public class BookingDto
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string ticketId { get; set; }
        public DateTime? boughtAt { get; set; }
        public int amount { get; set; }
        public decimal? price { get; set; }
    }
}
