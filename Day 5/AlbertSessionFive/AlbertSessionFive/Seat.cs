using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertSessionFive
{
    public enum SeatState
    {
        Empty = 0,
        Bought = 1,
        Occupied = 2
    }

    public class Seat
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public SeatState State { get; set; }
        public bool IsAvailable { get; set; } = true;
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Row {Row}, Col {Column}";
        }
    }

}
