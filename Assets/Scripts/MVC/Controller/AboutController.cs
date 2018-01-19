using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using View.Impl;

namespace Controller
{
    class AboutController : IController
    {
        public AboutView View;

        public GameObject AboutUI;

        public void Init()
        {
            View.OnClickAboutChanged += View_OnClickAboutChanged;
        }

        private void View_OnClickAboutChanged(object sender, View.BlockViewClickChangedEventArgs e)
        {
            AboutUI.SetActive(false);
        }
    }
}
