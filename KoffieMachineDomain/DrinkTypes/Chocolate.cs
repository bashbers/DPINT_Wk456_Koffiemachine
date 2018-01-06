using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Chocolate : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public string Name => "Chocolate";


        public Chocolate()
        {
            BasePrice = 1.50;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Filling with Chocolate...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
