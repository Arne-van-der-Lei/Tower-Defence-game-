using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.Unity;

namespace Systems.UI
{
    public class PrefabSystem : ReactiveSystem<GameEntity>
    {
        private readonly Transform _container = new GameObject("Views").transform;
        private readonly GameContext _context;

        public PrefabSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Prefab.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPrefab && !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                GameObject prefab = Resources.Load<GameObject>(entity.prefab.Value);
                GameObject gameObject = Object.Instantiate(prefab, _container);

                if (entity.hasStartPosition)
                    gameObject.transform.position = entity.startPosition.Value;
                
                if (entity.hasStartRotation)
                    gameObject.transform.rotation = entity.startRotation.Value;

                gameObject.Link(entity, _context);

                entity.AddView(gameObject);
            }
        }
    }
}
