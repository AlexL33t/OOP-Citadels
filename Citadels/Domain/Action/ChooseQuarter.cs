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

        public override void Do(int[] indexes, List<object> answ, Flags flags)
        {
            if (indexes.Length > 1)
                throw new Exception("");

            field.PutQuartersInHand(player, new List<Quarter>() { (Quarter)answ[indexes[0]] });
            answ.RemoveAt(indexes[0]);
            field.PutQuartersOnDeck(new List<Quarter>() { (Quarter)answ[0] });
            flags.MainActionDone = true;
        }

        public override List<object> GetParam()
        {
            return new List<object>(field.TakeQuartersFromDeck(2));
        }

        public override InfoAct Info
        {
            get { return new InfoAct() { Name = "" }; }
        }
    }
}
