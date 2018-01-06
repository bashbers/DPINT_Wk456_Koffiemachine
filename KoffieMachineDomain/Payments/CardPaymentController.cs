using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Payments
{
    using System.Collections.ObjectModel;
    using Interface;
    public class CardPaymentController : IPaymentController
    {
        private Dictionary<string, double> _cashOnCards;

        public CardPaymentController()
        {
            InitializeCards();
        }

        public void InitializeCards()
        {
            _cashOnCards = new Dictionary<string, double>
            {
                ["Arjen"] = 5.0,
                ["Bert"] = 3.5,
                ["Chris"] = 7.0,
                ["Daan"] = 6.0
            };
        }

        public double PayDrink(string name, double remainingPriceToPay)
        {
            var insertedMoney = GetCardAmountLeft(name);
            if (remainingPriceToPay <= insertedMoney)
            {
                _cashOnCards[name] = insertedMoney - remainingPriceToPay;
                return 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                _cashOnCards[name] = 0;

                return insertedMoney;
            }
        }

        public ICollection<string> GetCardKeys()
        {
            return _cashOnCards.Keys;
        }

        public double GetCardAmountLeft(string name)
        {
            if (_cashOnCards.ContainsKey(name))
            {
                return _cashOnCards[name];
            }

            return -1;
        }
    }
}
