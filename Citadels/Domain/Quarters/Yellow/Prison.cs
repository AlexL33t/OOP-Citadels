using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Prison : Quarter
    {
        public Prison()
        {
            Cost = 2;
            Color = QuarterColor.Yellow;
        }
    }
}
