using System.Collections.Generic;

namespace Citadels.Domain
{
    class King : Person
    {
        class Сoronation : Act
        {
            public Сoronation(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParameters()
            {
                return null;
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                field.Crown(player);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }

        public King()
        {
            Rank = 4;
            Color = QuarterColor.Yellow;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            return new List<Act>() { new Сoronation(player, person, field) };
        }
    }
}