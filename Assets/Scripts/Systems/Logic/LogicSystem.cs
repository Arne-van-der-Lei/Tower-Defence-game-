using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Logic
{
    public class LogicSystem : Feature
    {
        public LogicSystem(Contexts contexts) : base("Logic Systems")
        {
            Add(new MoveSystem(contexts));
            Add(new ShootSystem(contexts));
            Add(new BulletCollisionSystem(contexts));
            Add(new UpgradeTowerSystem(contexts));
            Add(new DamageSystem(contexts));
            Add(new DestroySystem(contexts));
        }
    }
}
