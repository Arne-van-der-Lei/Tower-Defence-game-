using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using View.Impl;

namespace Controller
{

    class MainMenuController : IController
    {
        public MainMenuView View;

        public GameObject MainMenuUI;
        public GameObject AboutUI;

        public void Init()
        {
            View.OnClickStartChanged += View_OnClickStartChanged;
            View.OnClickAboutChanged += View_OnClickAboutChanged;
        }

        private void View_OnClickAboutChanged(object sender, View.BlockViewClickChangedEventArgs e)
        {
            AboutUI.SetActive(true);
        }

        private void View_OnClickStartChanged(object sender, View.BlockViewClickChangedEventArgs e)
        {
            MainMenuUI.SetActive(false);

            TozerDefenceAplicqtion.Instance.Restart();
        }
    }
}
