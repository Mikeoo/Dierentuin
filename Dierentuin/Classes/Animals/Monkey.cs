using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dierentuin.Classes.Animals
{
    class Monkey : Animal
    {
        public Monkey()
        {
            Species = this.GetType().Name;
            Energy = 20;
        }
        public override int UseEnergy()
        {
            return Energy -= 2;
        }

        public override void Eat()
        {
            Energy += 10;
        }
    }
}
