using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertSession2
{
    internal class DB
    {
        private static albertTwoEntities1 context;
        public static albertTwoEntities1 Gt() {
            if (context == null)
            {
                context = new albertTwoEntities1();
            }
            return context;
        }
    }
}
