using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using Interface;
    public abstract class BaseDrinkDecorator : IDrink
    {
        public string Name { get; set; }

        public double BasePrice { get; set; }

        protected IDrink nextDrink;
        public BaseDrinkDecorator(IDrink drink)
        {
            nextDrink = drink;
        }

        public virtual double GetPrice()
        {
            return nextDrink.GetPrice();
        }

        public virtual ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            return nextDrink.LogDrinkMaking(log);
        }
    }
}
