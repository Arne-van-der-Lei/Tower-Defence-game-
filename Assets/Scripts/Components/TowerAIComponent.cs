using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    public class TowerAiComponentEventArgs : EventArgs
    {
        public float range;
        public float shootSpeed;
        public int tier;

        public TowerAiComponentEventArgs(float range, float shootSpeed,int tier)
        {
            this.range = range;
            this.shootSpeed = shootSpeed;
            this.tier = tier;
        }
    }

    public class TowerAIComponent :IComponent
    {
        public EventHandler<TowerAiComponentEventArgs> TowerAiEventHandler;
        public float counter;

        public float Range { get { return _range; }
            set
            {
                _range = value;
                if(TowerAiEventHandler != null)
                    TowerAiEventHandler(this, new TowerAiComponentEventArgs(_range, _shootSpeed,_tier));
            }
        }
        private float _range;

        public float Shootspeed {
            get { return _shootSpeed; }
            set
            {
                _shootSpeed = value;
                if (TowerAiEventHandler != null)
                    TowerAiEventHandler(this, new TowerAiComponentEventArgs(_range, _shootSpeed,_tier));
            }
        }
        private float _shootSpeed;

        public int Tier
        {
            get { return _tier; }
            set
            {
                _tier = value;
                if (TowerAiEventHandler != null)
                    TowerAiEventHandler(this, new TowerAiComponentEventArgs(_range, _shootSpeed,_tier));
            }
        }
        private int _tier;

        public TowerAIComponent(float counter, float range, float shootspeed)
        {
            this.counter = counter;
            this._range = range;
            this._shootSpeed = shootspeed;
        }

        public TowerAIComponent()
        {
        }
    }
}
