using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.Domain
{
    public class Player
    {
        public string Name { get; private set; }
        public string Id { get; private set; }

        public Player(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        #region entity semantics
        protected bool Equals(Player other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Player: {0} {1}", Name, Id);
        }
        #endregion
    }
}
