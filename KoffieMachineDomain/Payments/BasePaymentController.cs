using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    using Interface;
    public abstract class BasePaymentController : IPaymentController
    {
        public virtual void Initialize()
        {

        }
    }
}
