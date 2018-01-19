using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View.impl;

namespace Controller
{
    class StartController : IController
    {
        public StartModel Model;
        public StartView View;

        public void Init()
        {
            View.OnNextWaveChanged += View_OnNextWaveChanged;
        }

        private void View_OnNextWaveChanged(object sender, View.StartViewStartChangedEventArgs e)
        {
            Model.Spawn();
        }
    }
}
