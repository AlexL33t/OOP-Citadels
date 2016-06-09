using System.Collections.Generic;

namespace Citadels.Domain
{
    class Architect : Person
    {
        class GetQuartersForArchitect : Act
        {
            public GetQuartersForArchitect(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParameters()
            {
                return null;
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                var quarters = field.TakeQuartersFromDeck(2);
                field.PutQuartersOnHand(player, quarters);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }

        public Architect()
        {
            Rank = 7;
            MaxCountOfTakenQuartersFromDeck = 3;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            if (flags.MainActionDone && !flags.AddActionDone)
                return new List<Act>() { new GetQuartersForArchitect(player, person, field) };
            return new List<Act>();
        }
    }
}