using UnityEngine;
using Zenject;



public class FactoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DI.BulletFactory>().To<DI.BulletFactory>().AsSingle();
        Container.Bind<DI.EnemyFactory>().To<DI.EnemyFactory>().AsSingle();
    }
}