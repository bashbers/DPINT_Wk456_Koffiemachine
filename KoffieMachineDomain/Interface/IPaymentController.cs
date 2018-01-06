using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Interface
{
    interface IPaymentController
    {
        double PayDrink(string name, double remainingPriceToPay);
    }
}
