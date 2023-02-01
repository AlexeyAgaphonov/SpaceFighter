using UnityEngine;
using Zenject;

public class EnemyPrefubInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _meteorPrefub;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("MeteorPrefub").FromInstance(_meteorPrefub);
    }
}