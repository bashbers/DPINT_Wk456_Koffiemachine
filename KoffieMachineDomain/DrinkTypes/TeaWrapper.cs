using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.DrinkTypes
{
    using TeaAndChocoLibrary;

    public class TeaWrapper : BaseDrink
    {
        private readonly Tea tea;

        public TeaWrapper(Tea tea)
        {
            this.tea = tea;
            TeaBlend = tea.Blend;

            BasePrice = 1.33;
            Name = "Tea";
            SugarAmount = (Amount)tea.AmountOfSugar;
        }

        public TeaBlend TeaBlend { get; set; }

        public override ICollection<string> LogDrinkMaking(ICollection<string> log)
        {
            log.Add("Filling with hot water...");
            log.Add($"Finished making {Name} with {TeaBlend.Name}");
            return log;
        }
    }
}
