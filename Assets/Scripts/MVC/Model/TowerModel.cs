using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
    class voidChangedEventArgs : EventArgs
    {
        public voidChangedEventArgs()
        {
        }
    }
    class TowerModel
    {

        public event EventHandler<GameEntityChangedEventArgs> OnValueChanged;
        public event EventHandler<voidChangedEventArgs> OnColorChanged;

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
                OnColorChanged(this, new voidChangedEventArgs());
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
                OnColorChanged(this, new voidChangedEventArgs());
                OnValueChanged(this, new GameEntityChangedEventArgs(_tower, _block));
            }
        }

    }
}
