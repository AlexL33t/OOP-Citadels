﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Harbor : Quarter
    {
        public Harbor()
        {
            Cost = 3;
            Color = QuarterColor.Green;
        }
    }
}
