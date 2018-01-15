using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Logic
{
    class UpgradeTowerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public UpgradeTowerSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities)
            {
                if (!entity.hasTileTower)
                {
                    entity.AddTileTower(_contexts.game.CreateTower(0, entity.view.Value.transform.position, Quaternion.identity),true);
                }
                else
                {
                    entity.tileTower.Tower.towerAI.range += 2;
                    entity.tileTower.Tower.towerAI.Shootspeed *= 0.9f;
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTowerUpgrade && entity.isTile;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TowerUpgrade.Added());
        }
    }
}
