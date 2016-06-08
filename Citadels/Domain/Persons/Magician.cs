using System;
using System.Collections.Generic;

namespace Citadels.Domain
{
    class Magician : Person
    {
        class ExchangeQuartersWithPlayer : Act
        {
            public ExchangeQuartersWithPlayer(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParam()
            {
                return new List<object>(field.Players);
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                var magicianQuarters = field.TakeAllQuartersFromHand(player);
                var playerQuarters = field.TakeAllQuartersFromHand((Player)answ[choice[0]]);
                field.PutQuartersInHand((Player)answ[choice[0]], magicianQuarters);
                field.PutQuartersInHand(player, playerQuarters);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }

        class ExchangeQuartersWithFreeQuarters : Act
        {
            public ExchangeQuartersWithFreeQuarters(Player player, Person person, GameField field) :
                base(player, person, field) { }

            public override List<object> GetParam()
            {
                return new List<object>(field.Players);
            }

            public override void Do(int[] choice, List<object> answ, Flags flags)
            {
                if (choice.Length > field.ShowQuarterInHand(player).Count)
                    throw new Exception("");

                var magicianQuarters = field.TakeQuartersFromHand(player, choice);
                var deckQuarters = field.TakeQuartersFromDeck(choice.Length);
                field.PutQuartersOnDeck(deckQuarters);
                flags.AddActionDone = true;
            }

            public override InfoAct Info
            {
                get { return new InfoAct() { Name = "" }; }
            }
        }
        
        public Magician()
        {
            Rank = 3;
        }

        public override List<Act> GetPossibleActons(Player player, Person person, Flags flags, GameField field)
        {
            return new List<Act>() { new ExchangeQuartersWithPlayer(player, person, field),
            new ExchangeQuartersWithFreeQuarters(player, person, field)};
        }
    }
}
