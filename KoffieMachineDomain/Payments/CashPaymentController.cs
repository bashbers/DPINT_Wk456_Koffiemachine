using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CashPaymentController
    {
        public double PayDrink(double insertedMoney, double remainingPriceToPay)
        {
            return Math.Max(Math.Round(remainingPriceToPay - insertedMoney, 2), 0);
        }
    }
}
