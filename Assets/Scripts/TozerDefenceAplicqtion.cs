using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;
using Entitas.Unity;
using Controller;
using View.impl;
using Systems.Logic;
using Model;

public class TozerDefenceAplicqtion : MonoBehaviour {

    public Transform SpawnpointEnemys;

    public MoneyView MoneyView;
    public TowerView view;

    public static TozerDefenceAplicqtion Instance;

    private MoneyModel MoneyModel;

    RootSystem _rootSystem;

    List<IController> _controllers;

	// Use this for initialization
	void Start () {
        Instance = this;

        _controllers = new List<IController>();

        Contexts contexts = Contexts.sharedInstance;
        GameContext context = contexts.game;
        _rootSystem = new RootSystem(contexts);

        _rootSystem.Initialize();

        HexGenerator.Instance = GetComponent<HexGenerator>();

        context.CreateEnemy(1, SpawnpointEnemys.position, SpawnpointEnemys.rotation, transform);
        //context.CreateTower(2, new Vector3(0, 0, 0), Quaternion.identity);

        MoneyModel = new MoneyModel();
        MoneyController MCont = new MoneyController
        {
            View = MoneyView,
            Model = MoneyModel
        };
        MCont.Init();
        MoneyModel.Money = 40;

        TowerController TCont = new TowerController
        {
            View = view
        };
        TowerModel model = new TowerModel();
        TCont.Entity = model;
        TCont.Init();
        UpgradeTowerSystem.model = model;

        foreach (Block cell in HexGenerator.Instance.GetBlocks())
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

    public int Money
    {
        get
        {
            return MoneyModel.Money;
        }

        set
        {
            MoneyModel.Money = value;
        }
    }
}
