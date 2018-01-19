using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using View;

namespace Controller
{
    public class PlayerHealthController : IController
    {
        public IPlayerHealthView View;
        public PlayerHealthModel Model;
        public GameObject MainMenuUI;

        public void Init()
        {
            Model.OnHealthChanged += Model_OnHealthChanged;
        }

        private void Model_OnHealthChanged(object sender, MoneyChangedEventArgs e)
        {
            View.Health = e.Money;

            if(e.Money == 0)
            {
                MainMenuUI.SetActive(true);
            }
        }
    }
}
