using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbertSession2
{
    internal class DB
    {
        private static albertTwoEntities2 context;
        public static albertTwoEntities2 Gt() {
            if (context == null)
            {
                context = new albertTwoEntities2();
            }
            return context;
        }
    }
}
