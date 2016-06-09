using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public abstract class Act
    {
        protected GameField field;
        protected Player player;
        protected Person person;

        public abstract InfoAct Info { get; }
        public abstract List<object> GetParameters();
        public abstract void Do(int[] choice, List<object> answ, Flags flags);

        public Act(Player player, Person person, GameField field)
        {
            this.field = field;
            this.person = person;
            this.player = player;
        }

    }
}