using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Logic
{
    class ShootSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;

        public ShootSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                Transform transform = entity.view.Value.GetComponent<ShootSpot>().ShootPosition;
                _contexts.game.CreateBullet(transform.position, transform.rotation,entity.bulletPrefab.prefab,entity.bulletPrefab.flyspeed,entity.shoot.enemy,entity.bulletPrefab.damage);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasShoot;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Shoot.Added());
        }
    }
}
