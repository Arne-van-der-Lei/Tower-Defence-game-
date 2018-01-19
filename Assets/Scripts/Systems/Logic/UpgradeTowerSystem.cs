using Components;
using Entitas;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using View.impl;

namespace Systems.Logic
{
    class UpgradeTowerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public static TowerModel model;

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
                    if (TozerDefenceAplicqtion.Instance.Money >= 20)
                    {
                        entity.AddTileTower(_contexts.game.CreateTower(0, entity.view.Value.transform.position, Quaternion.identity), true);
                        model.Tower = entity.tileTower.Tower;
                        model.Block.view.Value.GetComponent<BlockView>().Color = true;
                        TozerDefenceAplicqtion.Instance.Money -= 20;
                    }
                }
                else
                {
                    if (TozerDefenceAplicqtion.Instance.Money >= (int)(20 * entity.tileTower.Tower.towerAI.Tier * 1.1f))
                    {
                        entity.tileTower.Tower.towerAI.Range += 2;
                        entity.tileTower.Tower.towerAI.Shootspeed *= 0.9f;
                        entity.tileTower.Tower.towerAI.Tier++;
                        TozerDefenceAplicqtion.Instance.Money -= (int)(20 * (entity.tileTower.Tower.towerAI.Tier - 1) * 1.1f);
                    }
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
