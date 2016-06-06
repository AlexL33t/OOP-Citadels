using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Cathedral : Quarter
    {
        public Cathedral()
        {
            Cost = 4;
            Color = QuarterColor.Blue;
        }
    }
}
