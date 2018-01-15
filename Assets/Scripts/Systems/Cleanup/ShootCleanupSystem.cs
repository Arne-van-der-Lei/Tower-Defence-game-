using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Cleanup
{
    class ShootCleanupSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _identifiableTowers;
        private GameContext _context;

        public ShootCleanupSystem(Contexts contexts)
        {
            _identifiableTowers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Shoot));
            _context = contexts.game;
        }

        public void Cleanup()
        {
            for(int i = _identifiableTowers.count-1; i >= 0; i --)
            {
                _identifiableTowers.ElementAt(i).RemoveShoot();
            }
        }
    }
}
