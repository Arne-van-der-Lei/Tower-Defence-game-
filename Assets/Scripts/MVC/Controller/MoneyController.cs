using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View.impl;

namespace Controller
{
    public class MoneyController : IController
    {
        public MoneyModel Model;

        public MoneyView View;

        public void Init()
        {

            Model.OnMoneyChanged += Model_OnMoneyChanged;
        }

        private void Model_OnMoneyChanged(object sender, MoneyChangedEventArgs e)
        {
            View.Money = e.Money + "";
        }
    }
}
