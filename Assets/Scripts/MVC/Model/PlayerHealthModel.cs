using System;

namespace Model {

    public class PlayerHealthModel
    {

        public event EventHandler<MoneyChangedEventArgs> OnHealthChanged;
    
        private int _Health;

        public PlayerHealthModel(int Health)
        {
            _Health = Health;
        }

        public int Health
        {
            set
            {
                _Health = value;
                OnHealthChanged(this, new MoneyChangedEventArgs(_Health));
            }

            get
            {
                return _Health;
            }
        }
    }
}