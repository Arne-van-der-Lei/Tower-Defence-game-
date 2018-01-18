using System;

namespace Model
{
    public class MoneyChangedEventArgs : EventArgs
    {

        public int Money;

        public MoneyChangedEventArgs(int money)
        {
            Money = money;
        }
    }

    public class MoneyModel
    {
        public event EventHandler<MoneyChangedEventArgs> OnMoneyChanged;

        private int _Money;
        public int Money
        {
            get
            {
                return _Money;
            }

            set
            {
                _Money = value;
                OnMoneyChanged(this, new MoneyChangedEventArgs(_Money));
            }
        }
    }
}