using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AESessionThreeWPF.ModelDTO
{
    public class DB
    {
        private static albertSessionThreeEntities1 context;

        public static albertSessionThreeEntities1 GT( )
        {
            if(context == null)
            {
                context = new albertSessionThreeEntities1();
            }

            return context;
        }
    }
}
