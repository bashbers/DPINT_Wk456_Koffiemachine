using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using Interface;
    public class BaseDrink : IDrink
    {
        public string Name { get; set; }
        public double BasePrice { get; set; }

        protected IDrink nextDrink;

        public BaseDrink()
        {
            BasePrice = .50;
            Name = "Koffie";
        }

        public double GetPrice()
        {
            return nextDrink.BasePrice + 
        }

        public ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Making base drink..");
            return nextDrink.LogDrinkMaking(log);
        }
    }
}
