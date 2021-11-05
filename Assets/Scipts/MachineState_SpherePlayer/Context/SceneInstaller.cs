using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller, IInitializable
{
    public MenuScreenView menuScreenView;
    public CrystallCounterView crystallCounterView;
    public GameObject gameManagerPrefab;
    public GameObject crystallSpawnerPrefab;
    public GameObject tileSpawnerPrefab;
    public GameObject playerPrefab;

    public override void InstallBindings()
    {
        BindMenuScreenMvc();
        BindCrystallCounterMvc();

        BindMenuScreenView();
        BindCrystallCounterView();
        BindGameManger();
        BindInstallerInterfaces();
        BindingCrystallSpawner();
        BindingTileSpawner();
        BindingPlayerSpawner();
    }

    private void BindMenuScreenMvc()
    {
        Container.
            Bind<MenuScreenFactory>().
            FromInstance(new MenuScreenFactory(menuScreenView)).
            AsSingle();
    }

    private void BindCrystallCounterMvc()
    {
        Container.
            Bind<CrystalCounterFactory>().
            FromInstance(new CrystalCounterFactory(crystallCounterView)).
            AsSingle();
    }

    private void BindMenuScreenView()
    {
        Container.
            Bind<MenuScreenView>().
            FromInstance(menuScreenView).
            AsSingle();
    }

    private void BindCrystallCounterView()
    {
        Container.
            Bind<CrystallCounterView>().
            FromInstance(crystallCounterView).
            AsSingle();
    }

    private void BindGameManger()
    {
        GameManager gameManager = Container.
                    InstantiatePrefabForComponent<GameManager>(gameManagerPrefab);

        Container.
            Bind<GameManager>().
            FromInstance(gameManager).
            AsSingle();
    }

    private void BindInstallerInterfaces()
    {
        Container.
            BindInterfacesTo<SceneInstaller>().
            FromInstance(this).
            AsSingle();
    }

    private void BindingCrystallSpawner()
    {
        CrystallSpawner crystallSpawner = Container.
                    InstantiatePrefabForComponent<CrystallSpawner>(crystallSpawnerPrefab,
                    Vector3.zero, Quaternion.identity, null);

        Container.
            Bind<CrystallSpawner>().
            FromInstance(crystallSpawner).
            AsSingle();
    }

    private void BindingTileSpawner()
    {
        TileSpawner tileSpawner = Container.
                    InstantiatePrefabForComponent<TileSpawner>(tileSpawnerPrefab,
                    Vector3.zero, Quaternion.identity, null);

        Container.
            Bind<TileSpawner>().
            FromInstance(tileSpawner).
            AsSingle();
    }

    private void BindingPlayerSpawner()
    {
        PlayerControl playerControl = Container.
                    InstantiatePrefabForComponent<PlayerControl>(playerPrefab,
                    Vector3.zero, Quaternion.identity, null);

        Container.
            Bind<PlayerControl>().
            FromInstance(playerControl).
            AsSingle();
    }

    public void Initialize()
    {
        MenuScreenFactory factoryMenuScreen = Container.Resolve<MenuScreenFactory>();
        factoryMenuScreen.InitializeFactory();

        //Crystallcounter MVC model
        CrystalCounterFactory factoryCrystalCounter = Container.Resolve<CrystalCounterFactory>();
        factoryCrystalCounter.InitializeFactory();

    }
}
