using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Milk : BaseDrink
    {

        public Milk(BaseDrink drink, Amount milkAmount)
        {
            _nextDrink = drink;
            MilkAmount = milkAmount;
            BasePrice += 0.25;
            Name = _nextDrink.Name;
        }

        public override double GetPrice()
        {
            return _nextDrink.GetPrice() + 0.25;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Setting milk amount to {MilkAmount}.");
            log.Add("Adding milk...");
           
            return _nextDrink.LogDrinkMaking(log);
        }
    }
}
