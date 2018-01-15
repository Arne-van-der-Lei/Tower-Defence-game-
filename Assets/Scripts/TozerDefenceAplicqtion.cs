using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;
using Entitas.Unity;

public class TozerDefenceAplicqtion : MonoBehaviour {

    public Transform SpawnpointEnemys;

    RootSystem _rootSystem;

	// Use this for initialization
	void Start () {

        Contexts contexts = Contexts.sharedInstance;
        GameContext context = contexts.game;
        _rootSystem = new RootSystem(contexts);

        _rootSystem.Initialize();

        context.CreateEnemy(1, SpawnpointEnemys.position, SpawnpointEnemys.rotation, transform);
        //context.CreateTower(2, new Vector3(0, 0, 0), Quaternion.identity);

        HexGenerator gen = GetComponent<HexGenerator>();

        foreach(Block cell in gen._cells)
        {
            GameEntity e = context.CreateTile(cell.gameObject);
            cell.gameObject.Link(e, context);
        }
	}
	
	// Update is called once per frame
	void Update () {

        _rootSystem.Execute();
        _rootSystem.Cleanup();
	}

    private void OnDestroy()
    {
        _rootSystem.TearDown();
    }
}
