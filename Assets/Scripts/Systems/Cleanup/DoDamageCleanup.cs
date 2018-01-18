using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Cleanup
{
    class DoDamageCleanup : ICleanupSystem
    {
        private IGroup<GameEntity> _identifiableDamages;
        private GameContext _context;

        public DoDamageCleanup(Contexts contexts)
        {
            _identifiableDamages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.DoDamage));
            _context = contexts.game;
        }

        public void Cleanup()
        {
            for (int i = _identifiableDamages.count - 1; i >= 0; i--)
            {
                _identifiableDamages.ElementAt(i).RemoveDoDamage();
            }
        }
    }
}
