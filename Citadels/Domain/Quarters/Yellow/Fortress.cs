using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Fortress : Quarter
    {
        public Fortress()
        {
            Cost = 5;
            Color = QuarterColor.Yellow;
        }
    }
}
