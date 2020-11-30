using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin.Classes.Animals
{
    class Lion : Animal
    {
        public Lion()
        {
            Species = this.GetType().Name;
            Energy = 10;
        }
        public override int UseEnergy()
        {
            return Energy -= 10;
        }

        public override void Eat()
        {
            Energy += 25;
        }
    }
}
