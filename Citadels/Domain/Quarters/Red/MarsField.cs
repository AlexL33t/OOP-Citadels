using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class MarsField : Quarter
    {
        public MarsField()
        {
            Cost = 3;
            Color = QuarterColor.Red;
        }
    }
}
