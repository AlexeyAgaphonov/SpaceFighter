using UnityEngine;
using Zenject;


namespace DI
{
    public class EnemyPrefubInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _meteorPrefub;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("MeteorPrefub").FromInstance(_meteorPrefub);
        }
    }
}
