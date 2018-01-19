using Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public sealed partial class GameContext
{
    public GameEntity CreateEnemy(int id, Vector3 startPosition, Quaternion startRotation,Transform target,float health,int cash)
    {
        var entity = CreateEntity();
        entity.isEnemy = true;
        entity.AddHealth(health,health);
        entity.AddStartPosition(startPosition);
        entity.AddStartRotation(startRotation);
        entity.AddMoveSpeed(80.0f);
        entity.AddPrefab("Prefabs/Enemie");
        entity.AddPoint(target.position);
        entity.AddEnemyAi(HexGenerator.Instance.FindPathGreedyBestFirstSearch(HexGenerator.Instance.GetBlock(startPosition), HexGenerator.Instance.GetBlocks()[HexGenerator.Instance.GetBlocks().Length - 1]),0);
        entity.AddMoney(cash);

        return entity;
    }

    public GameEntity CreateTower(int id, Vector3 startPosition, Quaternion startRotation)
    {
        var entity = CreateEntity();

        entity.isTower = true;
        entity.AddHealth(10, 10);
        entity.AddStartPosition(startPosition);
        entity.AddStartRotation(startRotation);
        entity.AddPrefab("Prefabs/Tower");
        entity.AddBulletPrefab(1, 1600.0f, "Prefabs/Bullet");
        entity.AddTowerAI(0,5,1,1);

        return entity;
    }

    public GameEntity CreateBullet(Vector3 startPosition,Quaternion startRotation,string prefab,float movespeed,Transform target,float damage)
    {
        var entity = CreateEntity();

        entity.isBullet = true;
        entity.AddPrefab(prefab);
        entity.AddMoveSpeed(movespeed);
        entity.AddPoint(target.position + new Vector3(0,0.5f,0));
        entity.AddStartPosition(startPosition);
        entity.AddStartRotation(startRotation);
        entity.AddDamage(damage);

        return entity;
    }

    public GameEntity CreateTile(GameObject obj)
    {
        var entity = CreateEntity();

        entity.isTile = true;
        entity.AddView(obj);

        return entity;
    }
}

public sealed partial class GameEntity
{
    public void AddTowerAI(float newCounter, float newRange, float newShootspeed,int tier)
    {
        var index = GameComponentsLookup.TowerAI;
        var component = CreateComponent<Components.TowerAIComponent>(index);
        component.counter = newCounter;
        component.Range = newRange;
        component.Shootspeed = newShootspeed;
        component.Tier = tier;
        AddComponent(index, component);
    }
}