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
            Rank = 5;
        }

        void GetMoneyForMerchant(Player merchant, GameField field)
        {
            field.AddMoneyInBank(merchant, 1);
        }
    }
}
