using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Logic
{
    class PlayerDamageSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _identifiableEnemys;
        private GameContext _context;

        public PlayerDamageSystem(Contexts contexts)
        {
            _identifiableEnemys = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PlayerDamage));
            _context = contexts.game;
        }

        public void Execute()
        {
            foreach(var enemy in _identifiableEnemys)
            {
                enemy.isDestroy = true;
                TozerDefenceAplicqtion.Instance.DamagePlayer(1);
            }
        }
    }
}
