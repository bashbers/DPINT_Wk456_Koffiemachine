using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    using KoffieMachineDomain.Enumerations;
    using KoffieMachineDomain.Payments;

    public class MainViewModel : ViewModelBase
    {
        private CardPaymentController cardPaymentController;
        private CashPaymentController cashPaymentController;
        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
            _coffeeStrength = Strength.Normal;
            _sugarAmount = Amount.Normal;
            _milkAmount = Amount.Normal;

            LogText = new ObservableCollection<string>
            {
                "Starting up...",
                "Done, what would you like to drink?"
            };

            cardPaymentController = new CardPaymentController();
            cashPaymentController = new CashPaymentController();

            PaymentCardUsernames = new ObservableCollection<string>(cardPaymentController.GetCardKeys());
            SelectedPaymentCardUsername = PaymentCardUsernames[0];
        }

        #region Drink properties to bind to
        private BaseDrink _selectedDrink;
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }
        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            if (_selectedDrink == null)
            {
                return;
            }

            var insertedMoney = cardPaymentController.GetCardAmountLeft(SelectedPaymentCardUsername);
            RemainingPriceToPay = cardPaymentController.PayDrink(SelectedPaymentCardUsername, RemainingPriceToPay);

            LogText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
            CheckRemainingPriceToPay();
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            RemainingPriceToPay = cashPaymentController.PayDrink(coinValue, RemainingPriceToPay);

            LogText.Add($"Inserted {coinValue.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
            CheckRemainingPriceToPay();

        });

        private void CheckRemainingPriceToPay()
        {
            if (RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }


        public double PaymentCardRemainingAmount
        {
            get { return cardPaymentController.GetCardAmountLeft(SelectedPaymentCardUsername); }
        }

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
        private Strength _coffeeStrength;
        public Strength CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private Amount _sugarAmount;
        public Amount SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private Amount _milkAmount;
        public Amount MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ICommand DrinkCommand => new RelayCommand<DrinkInformation>((info) => //left here
        {

            switch (info.Type)
            {
                case DrinkTypes.Normal:
                    _selectedDrink = DrinkFactory.CreateDrink(info.Name, CoffeeStrength);
                    break;
                case DrinkTypes.Sugar:
                    _selectedDrink = DrinkFactory.CreateSugarDrink(info.Name, CoffeeStrength, SugarAmount);
                    break;
                case DrinkTypes.Milk:
                    _selectedDrink = DrinkFactory.CreateMilkDrink(info.Name, CoffeeStrength, MilkAmount);
                    break;
                case DrinkTypes.SugarMilk:
                    _selectedDrink = DrinkFactory.CreateSugarAndMilkDrink(info.Name, CoffeeStrength, MilkAmount, SugarAmount);
                    break;
            }

            if (CheckSelectedDrink(info.Name))
                return;

            RemainingPriceToPay = _selectedDrink.GetPrice();
            LogText.Add($"Selected {SelectedDrinkName} with sugar, price: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}");
            RaisePropertyChanged(() => RemainingPriceToPay);
            RaisePropertyChanged(() => SelectedDrinkName);
            RaisePropertyChanged(() => SelectedDrinkPrice);
        });

        //Helper method
        private bool CheckSelectedDrink(string drinkName)
        {
            if (_selectedDrink == null)
            {
                LogText.Add($"Could not make {drinkName}, recipe not found.");
                return true;
            }
            return false;
        }

        #endregion Coffee buttons
    }
}