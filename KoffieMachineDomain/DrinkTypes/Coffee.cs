﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Coffee : BaseDrink
    {

        public virtual Strength DrinkStrength { get; set; }

        public Coffee(Strength coffeeStrength)
        {
            Name = "Coffee";
            DrinkStrength = coffeeStrength;
            BasePrice = 1.50;
        }

        public override double GetPrice()
        {
            return BasePrice;
        }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");
            log.Add($"Finished making {Name}");
            return log;
        }
    }
}
