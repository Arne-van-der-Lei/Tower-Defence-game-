using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    [Game]
    public class BulletPrefabComponent : IComponent
    {
        public float damage;
        public float flyspeed;
        public string prefab;
    }
}
