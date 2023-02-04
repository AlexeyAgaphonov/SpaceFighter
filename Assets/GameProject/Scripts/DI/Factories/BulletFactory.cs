using UnityEngine;
using Zenject;

namespace DI
{
    public class BulletFactory : IFactory<string, Vector2, Vector2, GameObject, GameObject>
    {
        [Inject(Id = "BulletsContainer")]
        private GameObject _bulletsContainer;

        readonly DiContainer _container;

        BulletFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(string tagOfOwner, Vector2 startPosition, Vector2 direction, GameObject prefub)
        {
            var instance = _container.InstantiatePrefab(prefub);
            instance.transform.parent = _bulletsContainer.transform;
            instance.transform.position = startPosition;
            instance.tag = tagOfOwner;
            var bullet = instance.GetComponent<SpaceFighter.Bullet>();

            return instance;
        }
    }
}
