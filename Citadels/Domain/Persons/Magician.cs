using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Magician : Person
    {
        public Magician()
        {
            Rank = 3;
            PersonActions = new List<Action<Player, Choice,GameField>>() { 
                ExchangeQuartersWithPlayer, 
                ExchangeQuartersWithFreeQuarters
            };
        }

        void ExchangeQuartersWithPlayer(Player magician, Choice choice, GameField field)
        {
            var magicianQuarters = field.TakeAllQuartersFromHand(magician);
            var playerQuarters = field.TakeAllQuartersFromHand(choice.Player);
            field.TakeQuartersOnHand(magician, magicianQuarters);
            field.TakeQuartersOnHand(choice.Player, playerQuarters);
        }

        void ExchangeQuartersWithFreeQuarters(Player magician, Choice choice, GameField field)
        {
            //var q = choice.quarters;
            var indices = new int[] { 1, 3, 4 };
            if (indices.Length > field.ShowQuarterOnHand(magician).Count)
                throw new Exception("");
            
            var magicianQuarters = field.TakeSeveralQuartersFromHand(magician, indices);
            var deckQuarters = field.TakeQuartersFromDeck(indices.Length);
            field.PutQuartersOnDeck(magician, deckQuarters);
        }
    }
}