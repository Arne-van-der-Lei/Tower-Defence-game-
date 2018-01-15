using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    [Game]
    public class HealthComponent : IComponent
    {
        public float Health;
        public float MaxHealth;
    }
}
