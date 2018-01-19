using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Systems.Input
{
    class TowerAISystem : IExecuteSystem
    {

        private IGroup<GameEntity> _identifiableTowers;
        private GameContext _context;

        public TowerAISystem(Contexts contexts)
        {
            _identifiableTowers = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TowerAI, GameMatcher.View));
            _context = contexts.game;
        }
        
        public void Execute()
        {
            foreach(var entity in _identifiableTowers)
            {
                entity.towerAI.counter += Time.deltaTime;
                if (entity.towerAI.counter > entity.towerAI.Shootspeed)
                {
                    
                    Collider[] colliders = Physics.OverlapSphere(entity.view.Value.transform.position, entity.towerAI.Range);
                    
                    if(colliders.Length > 1)
                    {
                        foreach(var collider in colliders)
                        {
                            if(collider.tag == "Enemy")
                            {
                                if(!entity.hasShoot)
                                    entity.AddShoot(collider.gameObject.transform);
                            }
                        }
                    }

                    entity.towerAI.counter -= entity.towerAI.Shootspeed;
                }
            }
        }
    }
}
