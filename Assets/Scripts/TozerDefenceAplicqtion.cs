using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems;
using Entitas.Unity;
using Controller;
using View.impl;
using Systems.Logic;
using Model;
using System;
using View.Impl;
using Entitas;

public class TozerDefenceAplicqtion : MonoBehaviour {

    public Transform SpawnpointEnemys;

    public MoneyView MoneyView;
    public StartView StartView;
    public AboutView AboutView;
    public MainMenuView MainMenuView;
    public PlayerHealthView PlayerHealthView;

    public GameObject MainMenuUI;
    public GameObject AboutUI;

    public TowerView view;

    public static TozerDefenceAplicqtion Instance;

    private MoneyModel MoneyModel;
    private StartModel StartModel;
    private PlayerHealthModel PlayerHealthModel;

    RootSystem _rootSystem;

    public void DamagePlayer(int v)
    {
        PlayerHealthModel.Health -= v;
    }

    public void Restart()
    {
        IGroup<GameEntity> group = Contexts.sharedInstance.game.GetGroup(GameMatcher.AnyOf(GameMatcher.Bullet, GameMatcher.Enemy));

        foreach (var entity in group)
        {
            entity.isDestroy = true;
        }

        group = Contexts.sharedInstance.game.GetGroup(GameMatcher.TileTower);

        foreach (var entity in group)
        {
            entity.tileTower.Tower.isDestroy = true;
            entity.tileTower.Tower = null;
        }

        MoneyModel.Money = 40;
        PlayerHealthModel.Health = 20;
    }

    List<IController> _controllers;

	// Use this for initialization
	void Start ()
    {
        Instance = this;

        _controllers = new List<IController>();

        Contexts contexts = Contexts.sharedInstance;
        GameContext context = contexts.game;
        _rootSystem = new RootSystem(contexts);

        _rootSystem.Initialize();

        HexGenerator.Instance = GetComponent<HexGenerator>();

        PlayerHealthModel = new PlayerHealthModel(20);

        PlayerHealthController PlayerHealthController = new PlayerHealthController
        {
            View = PlayerHealthView,
            Model = PlayerHealthModel,
            MainMenuUI = MainMenuUI
        };

        PlayerHealthController.Init();

        AboutController About = new AboutController
        {
            View = AboutView,
            AboutUI = AboutUI
        };

        About.Init();

        MainMenuController MainMenu = new MainMenuController
        {
            View = MainMenuView,
            MainMenuUI = MainMenuUI,
            AboutUI = AboutUI
        };

        MainMenu.Init();

        StartModel = new StartModel();

        StartController start = new StartController
        {
            View = StartView,
            Model = StartModel
        };

        start.Init();

        CreateMoneyController();

        TowerModel model = CreateTowerController();

        CreateTiles(context, model);
    }

    private void CreateMoneyController()
    {
        MoneyModel = new MoneyModel();
        MoneyController MCont = new MoneyController
        {
            View = MoneyView,
            Model = MoneyModel
        };
        MCont.Init();
        MoneyModel.Money = 40;
    }

    private TowerModel CreateTowerController()
    {
        TowerController TCont = new TowerController
        {
            View = view
        };
        TowerModel model = new TowerModel();
        TCont.Entity = model;
        TCont.Init();
        TowerDeleteSystem.model = model;
        UpgradeTowerSystem.model = model;
        return model;
    }

    private void CreateTiles(GameContext context, TowerModel model)
    {
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

    public void SpawnEnemies(int lvl)
    {
        Contexts.sharedInstance.game.CreateEnemy(1, SpawnpointEnemys.position + new Vector3(0,0,0), SpawnpointEnemys.rotation, transform, 4 * lvl, 2 * lvl);
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
