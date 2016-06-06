using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Shrine : Quarter
    {
        public Shrine()
        {
            Cost = 1;
            Color = QuarterColor.Blue;
        }
    }
}
