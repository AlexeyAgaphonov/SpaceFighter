using UnityEngine;
using Zenject;


namespace DI
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BulletFactory>().To<BulletFactory>().AsSingle();

            Container.Bind<EnemyFactory>().To<EnemyFactory>().AsSingle();
        }
    }
}
