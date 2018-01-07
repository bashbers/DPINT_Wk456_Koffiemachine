using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkTypes
{
    using TeaAndChocoLibrary;

    public class HotChocolateDeluxeWrapper : BaseDrink
    {
        private readonly HotChocolate _hotChocolate;
        public HotChocolateDeluxeWrapper(HotChocolate choco)
        {
            _hotChocolate = choco;
            _hotChocolate.MakeDeluxe();
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

