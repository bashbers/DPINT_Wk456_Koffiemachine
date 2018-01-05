﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Coffee : BaseDrink
    {
        
        public virtual bool HasSugar { get; set; }
        public virtual Amount SugarAmount { get; set; }
        public virtual bool HasMilk { get; set; }
        public virtual Amount MilkAmount { get; set; }
        public virtual Strength DrinkStrength { get; set; }

        public string Name => "Koffie";


        public Coffee()
        {
            
        }

        public double GetPrice()
        {
            return BaseDrink.BaseDrinkPrice;
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");

            if (HasSugar)
            {
                log.Add($"Setting sugar amount to {SugarAmount}.");
                log.Add("Adding sugar...");
            }

            if (HasMilk)
            {
                log.Add($"Setting milk amount to {MilkAmount}.");
                log.Add("Adding milk...");
            }

            log.Add($"Finished making {Name}");
        }
    }
}
