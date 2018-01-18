using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Components
{
    public class EnemyAiComponent : IComponent
    {
        public Block[] path;
        public int index;
    }
}
