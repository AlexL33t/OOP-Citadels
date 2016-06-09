using System.Collections.Generic;

namespace Citadels.Domain
{
    class Merchant : Person
    {
        class MerchantAction : Act
        {
            public MerchantAction(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParameters()
            {
                return null;
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                field.AddMoneyToBank(player, 1);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }

        public Merchant()
        {
            Rank = 6;
            Color = QuarterColor.Green;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            if (flags.MainActionDone && !flags.AddActionDone)
                return new List<Act>() { new MerchantAction(player, person, field) };
            return new List<Act>();
        }
    }
}