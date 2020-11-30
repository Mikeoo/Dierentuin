using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin.Classes
{
    abstract class Animal
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public string Species { get; set; }
        public abstract int UseEnergy();

        public virtual void Eat()
        {
            Energy += 25;
        }

        public override string ToString()
        {
            return this.Name + " the " + this.Species + ". energy: " + this.Energy;

        }
    }
}
