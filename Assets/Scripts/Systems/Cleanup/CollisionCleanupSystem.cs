using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Cleanup
{
    class CollisionCleanupSystem : ICleanupSystem
    {

        private IGroup<GameEntity> _identifiableCollisions;
        private GameContext _context;

        public CollisionCleanupSystem(Contexts contexts)
        {
            _identifiableCollisions = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Collision));
            _context = contexts.game;
        }

        public void Cleanup()
        {
            for (int i = _identifiableCollisions.count - 1; i >= 0; i--)
            {
                _identifiableCollisions.ElementAt(i).RemoveCollision();
            }
        }
    }
}
