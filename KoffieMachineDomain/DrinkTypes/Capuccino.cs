using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Capuccino : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public Capuccino(Strength coffeeStrength)
        {
            Name = "Capuccino";
            DrinkStrength = coffeeStrength;
            BasePrice = 3.5;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with Cappuccino...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
