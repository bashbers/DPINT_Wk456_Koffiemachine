using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using System.Collections;
    using Interface;

    public class CoffeeDecorator : BaseDrinkDecorator
    {
        public CoffeeDecorator(IDrink drink) : base(drink)
        {
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 2;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Adding coffee..");
            return nextDrink.LogDrinkMaking(log);
        }
    }
}
