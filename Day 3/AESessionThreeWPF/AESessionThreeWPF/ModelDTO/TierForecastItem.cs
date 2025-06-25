using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESessionThreeWPF.ModelDTO
{
    public class TierForecastItem
    {
        public string name { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
        public int saleability { get; set; }
        public bool isForecast { get; set; }
    }
}
