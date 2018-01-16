using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using View;

namespace Controller
{
    class TowerController : IController
    {
        public TowerModel Entity { private get; set; }
        public ITowerView View { private get; set; }


        public void Init()
        {
#if DEBUG
            Debug.Assert(Entity != null);
            Debug.Assert(View != null);
#endif
            

            //model change
            Entity.OnValueChanged += ModelValueChanged;

            //view change
            View.OnValueDeleteChanged += ViewDeleteChanged;
            View.OnValueUpgradeChanged += ViewUpgradeChanged;
        }

        private void ViewDeleteChanged(object sender, View.TowerViewValueDeleteChangedEventArgs eventArgs)
        {
            Entity.Block.isTowerDelete = true;
        }
        private void ViewUpgradeChanged(object sender, View.TowerViewValueUpgradeChangedEventArgs eventArgs)
        {
            Entity.Block.isTowerUpgrade = true;
        }
        private void ModelValueChanged(object sender, GameEntityChangedEventArgs eventArgs)
        {
            if(eventArgs.Tower != null)
                eventArgs.Tower.towerAI.TowerAiEventHandler += TowerValueChanged;
        }

        public void TowerValueChanged(object sender, Components.TowerAiComponentEventArgs eventArgs)
        {
            SetValue(eventArgs.range,eventArgs.shootSpeed);
        }

        private void SetValue(float range, float Shootspeed)
        {
            View.range = string.Format("{0}", range);
            View.speed = string.Format("{0}", Shootspeed);
        }
    }
}
