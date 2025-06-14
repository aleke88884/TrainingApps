using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertSession1.Models
{
   public class ContentUser
    {
        public string email { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string town_postalCode { get; set; }
        public DateTime birthDay { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public bool isBanned { get; set; }
    }
}
