using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Input
{
    class InputSystem : Feature
    {
        public InputSystem(Contexts contexts) : base("Input Systems")
        {
            Add(new TowerAISystem(contexts));
        }
    }
}
