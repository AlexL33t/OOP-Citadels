using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    class ChooseQuarter : Act
    {
        public ChooseQuarter(Player player, Person person, GameField field) :
            base(player, person, field) { }

        public override void Do(int[] indices, List<object> answ, Flags flags)
        {
            if (indices.Length > 1)
                throw new Exception("");

            field.PutQuartersOnHand(player, new List<Quarter>() { (Quarter)answ[indices[0]] });
            answ.RemoveAt(indices[0]);
            field.PutQuartersOnDeck(new List<Quarter>() { (Quarter)answ[0] });
            flags.MainActionDone = true;
        }

        public override List<object> GetParameters()
        {
            return new List<object>(field.TakeQuartersFromDeck(2));
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "Взять квартал" }; }
        }
    }
}
