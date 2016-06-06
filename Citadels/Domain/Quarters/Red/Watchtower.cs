using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Watchtower : Quarter
    {
        public Watchtower()
        {
            Cost = 1;
            Color = QuarterColor.Red;
        }
    }
}
