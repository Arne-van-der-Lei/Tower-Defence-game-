using Entitas;
using Entitas.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Logic
{
    class BulletCollisionSystem : ReactiveSystem<GameEntity>
    {
        Contexts _contexts;

        public BulletCollisionSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                if (entity.collision.collider.tag.Equals("Enemy"))
                {
                    GameEntity entityEnemy = entity.collision.collider.gameObject.GetComponent<EntityLink>().entity as GameEntity;
                    entityEnemy.AddDoDamage(entity.damage.Damage);
                    entity.isDestroy = true;
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCollision && entity.isBullet;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collision.Added());
        }
    }
}
