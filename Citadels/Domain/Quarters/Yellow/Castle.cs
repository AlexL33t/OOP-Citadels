using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Castle : Quarter
    {
        public Castle()
        {
            Cost = 4;
            Color = QuarterColor.Yellow;
        }
    }
}
