using Entitas;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Logic
{
    class TowerDeleteSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public static TowerModel model;

        public TowerDeleteSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.tileTower.Tower.isDestroy = true;
                entity.RemoveTileTower();
                model.Tower = null;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTowerDelete && entity.isTile;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TowerDelete.Added());
        }
    }
}
