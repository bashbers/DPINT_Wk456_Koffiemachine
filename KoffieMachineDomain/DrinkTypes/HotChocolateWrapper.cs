using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkTypes
{
    using TeaAndChocoLibrary;

    public class HotChocolateWrapper : BaseDrink
    {
        private readonly HotChocolate _hotChocolate;
        public HotChocolateWrapper(HotChocolate choco)
        {
            _hotChocolate = choco;
            Name = choco.GetNameOfDrink();
            BasePrice = 1.20;

        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            var buildsteps = _hotChocolate.GetBuildSteps();

            foreach (string s in buildsteps)
            {
                log.Add(s);
            }
            
            return log;
        }
    }
}

