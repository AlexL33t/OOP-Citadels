using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class TownHall : Quarter
    {
        public TownHall()
        {
            Cost = 5;
            Color = QuarterColor.Green;
        }
    }
}
