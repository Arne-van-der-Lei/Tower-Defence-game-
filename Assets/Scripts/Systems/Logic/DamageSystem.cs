using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Systems.Logic
{
    class DamageSystem : ReactiveSystem<GameEntity>
    {
        Contexts _contexts;

        public DamageSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
            {
                e.health.Health -= e.doDamage.damage;
                if(e.health.Health <= 0)
                {
                    e.isDestroy = true;
                    TozerDefenceAplicqtion.Instance.Money += e.money.Value;
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDoDamage & entity.hasHealth;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DoDamage.Added());
        }
    }
}
