using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CafeAuLait : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public CafeAuLait(Strength coffeeStrength)
        {
            Name = "CafeAuLait";
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
            log.Add("Filling with CafeAuLait...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
