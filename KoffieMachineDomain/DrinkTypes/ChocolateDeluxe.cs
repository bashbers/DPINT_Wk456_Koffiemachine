using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class ChocolateDeluxe : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public string Name => "ChocolateDeluxe";


        public ChocolateDeluxe()
        {
            BasePrice = 2.75;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Filling with Chocolate Deluxe...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
