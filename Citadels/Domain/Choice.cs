using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Choice
    {
        public Person Person { get; private set; }
        public Player Player { get; private set; }
        public int n { get; private set; }
        public List<Quarter> Quarters { get; private set; }
        public int i { get; private set; }

        public Choice(Person person, Player player)
        {
            this.Person = person;
            this.Player = player;
        }

        public Choice(Person person, Player player, int n, List<Quarter> quarters, int i)
        {
            this.Person = person;
            this.Player = player;
            this.n = n;
            this.Quarters = quarters;
            this.i = i;
        }

        #region value semantics

        protected bool Equals(Choice other)
        {
            return Person.Equals(other.Person) && Player.Equals(other.Player);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Choice)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Player.GetHashCode() ^ 4 + Person.GetHashCode();
            }
        }
        #endregion
    }
}