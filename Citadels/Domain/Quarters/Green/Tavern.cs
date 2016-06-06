using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Tavern : Quarter
    {
        public Tavern()
        {
            Cost = 1;
            Color = QuarterColor.Green;
        }
    }
}
