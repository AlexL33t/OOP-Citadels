using System.Collections.Generic;

namespace Citadels.Domain
{
    class Assassin : Person
    {
        class KillPerson : Act
        {
            public KillPerson(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParam()
            {
                return new List<object>(field.Persons);
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                field.KillPerson((Person)answ[choice[0]]);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }

        public Assassin()
        {
            Rank = 1;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            return new List<Act>(){new KillPerson(player, person, field)};
        }
    }
}
