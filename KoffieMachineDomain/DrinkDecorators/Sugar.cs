using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Sugar : BaseDrink
    {
        public Sugar(BaseDrink drink, Amount sugarAmount)
        {
            _nextDrink = drink;
            drink.SugarAmount = sugarAmount;
            BasePrice = 0.15;
        }

        public override double GetPrice()
        {
            return _nextDrink.GetPrice() + 0.15;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Setting sugar amount to {SugarAmount}.");
            log.Add("Adding sugar...");
            return base.LogDrinkMaking(log);
        }
    }
}