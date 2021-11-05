using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller, IInitializable
{
    public GameObject gameManagerPrefab;
    public GameObject crystallSpawnerPrefab;
    public GameObject tileSpawnerPrefab;
    public GameObject playerPrefab;

    public override void InstallBindings()
    {
        BindGameManger();
        BindInstallerInterfaces();
        BindingCrystallSpawner();
        BindingTileSpawner();
        BindingPlayerSpawner();
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
        //throw new System.NotImplementedException();
    }
}
