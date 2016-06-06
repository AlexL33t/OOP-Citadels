using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Palazzo : Quarter
    {
        public Palazzo()
        {
            Cost = 5;
            Color = QuarterColor.Yellow;
        }
    }
}
