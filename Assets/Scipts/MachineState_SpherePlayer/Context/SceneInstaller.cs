using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller, IInitializable
{
    public MenuScreenView menuScreenView;
    public CrystallCounterView crystallCounterView;
    public GameScreenView gameScreenView;
    public GameObject gameManagerPrefab;
    public GameObject crystallSpawnerPrefab;
    public GameObject tileSpawnerPrefab;
    public GameObject playerPrefab;
    public GameObject dataManagerPrefab;
    public GameObject audioControllerPrefab;

    public override void InstallBindings()
    {
        BindDataManager();
        BindAudioController();
        BindMenuScreenView();
        BindCrystallCounterView();
        BindGameScreenView();
        BindGameManger();
        BindInstallerInterfaces();
        BindingCrystallSpawner();
        BindingTileSpawner();
        BindingPlayerSpawner();        
    }

    private void BindDataManager()
    {
        DataManager dataManager = Container.
                    InstantiatePrefabForComponent<DataManager>(dataManagerPrefab,
                    Vector3.zero, Quaternion.identity, null);

        Container.
            Bind<DataManager>().
            FromInstance(dataManager).
            AsSingle();
    }

    private void BindAudioController()
    {
        AudioController audioController = Container.
                    InstantiatePrefabForComponent<AudioController>(audioControllerPrefab,
                    Vector3.zero, Quaternion.identity, null);

        Container.
            Bind<AudioController>().
            FromInstance(audioController).
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

    private void BindGameScreenView()
    {
        Container.
            Bind<GameScreenView>().
            FromInstance(gameScreenView).
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
        
    }
}
