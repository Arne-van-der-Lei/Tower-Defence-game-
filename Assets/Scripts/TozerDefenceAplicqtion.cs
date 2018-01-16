using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;
using Entitas.Unity;
using Controller;
using View.impl;

public class TozerDefenceAplicqtion : MonoBehaviour {

    public Transform SpawnpointEnemys;
    public TowerView view;
    RootSystem _rootSystem;

    List<IController> _controllers;

	// Use this for initialization
	void Start () {
        _controllers = new List<IController>();
        Contexts contexts = Contexts.sharedInstance;
        GameContext context = contexts.game;
        _rootSystem = new RootSystem(contexts);

        _rootSystem.Initialize();

        context.CreateEnemy(1, SpawnpointEnemys.position, SpawnpointEnemys.rotation, transform);
        //context.CreateTower(2, new Vector3(0, 0, 0), Quaternion.identity);

        HexGenerator gen = GetComponent<HexGenerator>();

        TowerController TCont = new TowerController
        {
            View = view
        };
        Model.TowerModel model = new Model.TowerModel();
        TCont.Entity = model;
        TCont.Init();
        context.eventHandler = TCont.TowerValueChanged;

        foreach (Block cell in gen._cells)
        {
            GameEntity e = context.CreateTile(cell.gameObject);
            cell.gameObject.Link(e, context);
            BlockController cont = new BlockController
            {
                Grid = model,
                View = cell.GetComponent<BlockView>()
            };
            cont.Init();
            _controllers.Add(cont);
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
