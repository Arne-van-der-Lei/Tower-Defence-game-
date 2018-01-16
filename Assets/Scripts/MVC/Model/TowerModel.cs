using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class GameEntityChangedEventArgs : EventArgs
    {
        public GameEntity Tower;
        public GameEntity Block;

        public GameEntityChangedEventArgs(GameEntity tower, GameEntity block)
        {
            Tower = tower;
            Block = block;
        }
    }

    class TowerModel
    {

        public event EventHandler<GameEntityChangedEventArgs> OnValueChanged;

        private GameEntity _tower;
        private GameEntity _block;

        public GameEntity Tower
        {
            get
            {
                return _tower;
            }

            set
            {
                _tower = value;
                OnValueChanged(this, new GameEntityChangedEventArgs(_tower, _block));
            }
        }
        public GameEntity Block
        {
            get
            {
                return _block;
            }

            set
            {
                _block = value;
                OnValueChanged(this, new GameEntityChangedEventArgs(_tower, _block));
            }
        }

    }
}
