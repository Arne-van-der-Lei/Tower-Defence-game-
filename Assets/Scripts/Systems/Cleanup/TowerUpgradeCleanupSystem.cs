using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Cleanup
{
    class TowerUpgradeCleanupSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _identifiableTowerUpgrades;
        private GameContext _context;

        public TowerUpgradeCleanupSystem(Contexts contexts)
        {
            _identifiableTowerUpgrades = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TowerUpgrade));
            _context = contexts.game;
        }

        public void Cleanup()
        {
            for (int i = _identifiableTowerUpgrades.count - 1; i >= 0; i--)
            {
                _identifiableTowerUpgrades.ElementAt(i).isTowerUpgrade = false;
            }
        }
    }
}
