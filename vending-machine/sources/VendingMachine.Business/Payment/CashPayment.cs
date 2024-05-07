using Nagarro.VendingMachine.PresentationLayer;
using VendingMachine.Business.Logging;

namespace Nagarro.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    { 
        private readonly ICashPaymentView cashPaymentView;
        private readonly List<decimal> banknotes = new List<decimal> { 100, 50, 10, 20, 5, 1 };
        private readonly List<decimal> coins = new List<decimal> { 0.5m, 0.1m, 0.05m, 0.01m };

        public string Name => "Cash Payment";

        public CashPayment(ICashPaymentView cashPaymentView)
        {
            this.cashPaymentView = cashPaymentView ?? throw new ArgumentNullException(nameof(cashPaymentView));
        }

        private decimal MoneyInsert(decimal productPrice)
        {
            decimal inputMoney = 0;
            decimal insertedMoney;
            string input;
            bool ok;

            while (inputMoney < productPrice)
            {
                input = cashPaymentView.AskForMoney(productPrice, inputMoney);

                if (input == "x" || input == "X")
                {
                    cashPaymentView.CashPaymentCanceled(inputMoney);

                    return -1;
                }

                insertedMoney = decimal.Parse(input);

                ok = false;
                foreach (decimal banknote in banknotes)
                {
                    if (insertedMoney == banknote)
                    {
                        inputMoney += insertedMoney;
                        ok = true;
                    }
                }
                foreach (decimal coin in coins)
                {
                    if (insertedMoney == coin)
                    {
                        inputMoney += insertedMoney;
                        ok = true;
                    }
                }

                if (!ok)
                {
                    cashPaymentView.InvalidBanknoteOrCoin();
                }
            }

            return inputMoney;
        }

        private void GiveBackChange(decimal changeMoney)
        {
            cashPaymentView.DisplayChangeOwed(changeMoney);

            foreach (decimal banknote in banknotes)
            {
                var numberOfBanknotes = (int)Math.Floor(changeMoney / banknote);
                if (numberOfBanknotes > 0)
                {
                    changeMoney = changeMoney - numberOfBanknotes * banknote;
                    cashPaymentView.GiveBackChange(banknote, numberOfBanknotes);
                }
            }

            foreach (decimal coin in coins)
            {
                var numberOfCoins = (int)Math.Floor(changeMoney / coin);
                if (numberOfCoins > 0)
                {
                    changeMoney = changeMoney - numberOfCoins * coin;
                    cashPaymentView.GiveBackChange(coin, numberOfCoins);
                }
            }
        }

        public bool Run(decimal price, out string paymentType)
        {
            paymentType = "cash";

            cashPaymentView.TotalOwedBalance(price);

            decimal paidMoney = MoneyInsert(price);

            if (paidMoney == -1)
            {
                return false;
            }

            GiveBackChange(paidMoney - price);

            return true;
        }
    }
}