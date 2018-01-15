using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Logic
{
    class MoveSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _identifiableEnemys;
        private GameContext _context;

        public MoveSystem(Contexts contexts)
        {
            _identifiableEnemys = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveSpeed,GameMatcher.View));
            _context = contexts.game;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _identifiableEnemys)
            {
                GameObject gameObject = entity.view.Value;
                if (entity.point.Value == null)
                {
                    entity.isDestroy = true;
                    return;
                }

                Rigidbody body = gameObject.GetComponent<Rigidbody>();
                Vector3 dir = -gameObject.transform.position + entity.point.Value.position;

                body.velocity = dir.normalized * entity.moveSpeed.Value * Time.deltaTime;
            }
        }
    }
}
