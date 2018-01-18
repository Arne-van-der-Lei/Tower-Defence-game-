using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Cleanup
{
    class CleanupSystem : Feature
    {
        public CleanupSystem(Contexts contexts) : base("Cleanup Systems")
        {
            Add(new ShootCleanupSystem(contexts));
            Add(new CollisionCleanupSystem(contexts));
            Add(new TowerUpgradeCleanupSystem(contexts));
            Add(new DoDamageCleanup(contexts));
        }
    }
}
