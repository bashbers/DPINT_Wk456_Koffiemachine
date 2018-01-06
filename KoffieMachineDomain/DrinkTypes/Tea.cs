using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Tea : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public string Name => "Tea";


        public Tea()
        {
            BasePrice = 1.50;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Filling with hot water...");
            log.Add($"Finished making {Name} \nDon't forget to pick your teabag.");
            return log;
        }
    }
}
