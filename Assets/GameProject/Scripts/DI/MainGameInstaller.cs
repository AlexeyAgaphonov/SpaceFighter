using UnityEngine;
using Zenject;

public class MainGameInstaller : MonoInstaller
{
    [SerializeField] private GameObject _bulletsContainer;
    [SerializeField] private GameObject _enemiesContainer;
    [SerializeField] private SpaceFighter.InputEvents _events;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("BulletsContainer").FromInstance(_bulletsContainer);

        Container.Bind<GameObject>().WithId("EnemiesContainer").FromInstance(_enemiesContainer);

        Container.Bind<SpaceFighter.InputEvents>().WithId("SpaceFighterEvents").FromInstance(_events);

        
    }
}