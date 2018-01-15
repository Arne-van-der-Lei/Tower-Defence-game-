using Entitas;
using Entitas.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Logic
{
    class DestroySystem : ReactiveSystem<GameEntity>
    {
        public DestroySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                if (entity.hasView)
                {
                    entity.view.Value.GetComponent<EntityLink>().Unlink();
                    GameObject.Destroy(entity.view.Value);
                }

                entity.Destroy();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroy;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroy.Added());
        }
    }
}
