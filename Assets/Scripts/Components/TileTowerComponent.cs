using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    public class TileTowerComponent : IComponent
    {
        public GameEntity Tower;
        public bool hasTower;
    }
}
