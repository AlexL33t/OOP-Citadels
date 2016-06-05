using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Merchant : Person
    {
        public Merchant()
        {
            Rank = 6;
            Color = QuarterColor.Green;
        }

        void GetMoneyForMerchant(Player merchant, GameField field)
        {
            field.AddMoneyToBank(merchant, 1);
        }
    }
}
