using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Estate : Quarter
    {
        public Estate()
        {
            Cost = 3;
            Color = QuarterColor.Yellow;
        }
    }
}
