using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Espresso : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public string Name => "Espresso";


        public Espresso(Strength coffeeStrength)
        {
            DrinkStrength = coffeeStrength;
            BasePrice = 2.50;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with Espresso...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
