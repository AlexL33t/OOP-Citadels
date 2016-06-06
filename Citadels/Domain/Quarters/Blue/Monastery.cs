using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Monastery : Quarter
    {
        public Monastery()
        {
            Cost = 3;
            Color = QuarterColor.Blue;
        }
    }
}
