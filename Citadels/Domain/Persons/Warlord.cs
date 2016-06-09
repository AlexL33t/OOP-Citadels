//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Citadels.Domain
//{
//    public class Warlord : Person
//    {
//        public Warlord()
//        {
//            Rank = 8;
//            Color = QuarterColor.Red;
//        }

//        void DestroyQuarter(Player warlord, Choice choice, GameField field)
//        {
//            var quarterCost = choice.Quarters[0].Cost;
//            if (quarterCost > field.ShowBankState(warlord) + 1)
//                throw new Exception("");
//            if (choice.Person is Bishop)
//                return;
//            field.DestroyQuarterInCity(choice.Player, choice.i);
//            if (quarterCost != 1)
//                field.TakeMoneyFromBank(warlord, quarterCost - 1);
//        }
//    }
//}
