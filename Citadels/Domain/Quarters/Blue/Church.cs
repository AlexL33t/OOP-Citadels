using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Church : Quarter
    {
        public Church()
        {
            Cost = 2;
            Color = QuarterColor.Blue;
        }
    }
}
