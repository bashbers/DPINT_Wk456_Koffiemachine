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

        public Amount MilkAmount { get; set; }

        public Strength CoffeeAmount { get; set; }

        public Amount SugarAmount { get; set; }
        public static double MilkPrice { get; set; }

        protected IDrink _nextDrink;

        public BaseDrink()
        {
            
            BasePrice = .50;
            Name = "Koffie";
        }

        public virtual double GetPrice()
        {
            return BasePrice;
        }

        public virtual ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            return _nextDrink.LogDrinkMaking(log);
        }
    }
}
