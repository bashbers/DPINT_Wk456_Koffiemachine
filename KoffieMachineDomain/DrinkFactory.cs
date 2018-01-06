using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using Interface;

    public class DrinkFactory
    {
        public static BaseDrink CreateDrink(string arg, Strength strength)
        {
            switch (arg)
            {
                case "Coffee":
                    return new Coffee(strength);
                case "Espresso":
                    return new Espresso(strength);
                case "Capuccino":
                    return new Capuccino(strength);
                case "Wiener Melange":
                    return new WienerMelange(strength);
                case "Café au Lait":
                    return new CafeAuLait(strength);
                case "Chocolate":
                    return new Chocolate();
                case "Chocolate Deluxe":
                    return new ChocolateDeluxe();
                case "Tea":
                    return new Tea();
                default:
                    return null;
            }
        }
        public static BaseDrink CreateSugarDrink(string arg, Strength strength, Amount sugarAmount)
        {
            switch (arg)
            {
                case "Coffee":
                    return new Sugar(new Coffee(strength), sugarAmount);
                case "Espresso":
                    return new Sugar(new Espresso(strength), sugarAmount);
                case "Capuccino":
                    return new Sugar(new Capuccino(strength), sugarAmount);
                case "Wiener Melange":
                    return new Sugar(new WienerMelange(strength), sugarAmount);
                case "Tea":
                    return new Sugar(new Tea(), sugarAmount); //Read coffeestrength as chocolatestrength
                default:
                    return null;
            }
        }
        public static BaseDrink CreateMilkDrink(string arg, Strength strength, Amount milkAmount)
        {
            switch (arg)
            {
                case "Coffee":
                    return new Milk(new Coffee(strength), milkAmount);
                case "Espresso":
                    return new Milk(new Espresso(strength), milkAmount);
                default:
                    return null;
            }
        }
        public static BaseDrink CreateSugarAndMilkDrink(string arg, Strength strength, Amount milkAmount, Amount sugarAmount)
        {
            switch (arg)
            {
                case "Coffee":
                    return new Sugar(new Milk(new Coffee(strength), milkAmount), sugarAmount);
                case "Espresso":
                    return new Sugar(new Milk(new Espresso(strength), milkAmount), sugarAmount);
                default:
                    return null;
            }
        }
    }
}
