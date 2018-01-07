using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using TeaAndChocoLibrary;

    public class DrinkInformation
    {
        public string Name { get; set; }
        public Enumerations.DrinkTypes Type { get; set; }
        public TeaBlend Blend { get; set; }
    }
}
