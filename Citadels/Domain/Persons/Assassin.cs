using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Assassin : Person
    {
        public Assassin()
        {
            Rank = 1;
        }

        public void ActionPerson(Choice choice, GameField field)
        {
            field.KillPerson(choice.Person);
        }
    }
}
