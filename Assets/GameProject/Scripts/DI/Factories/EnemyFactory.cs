using UnityEngine;
using Zenject;

namespace DI
{
    public class EnemyFactory : IFactory<GameObject, Vector2, GameObject>
    {
        [Inject(Id = "EnemiesContainer")]
        private GameObject _enemiesContainer;

        readonly DiContainer _container;

        EnemyFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(GameObject prefub, Vector2 startPosition)
        {
            var instance = _container.InstantiatePrefab(prefub);
            instance.transform.parent = _enemiesContainer.transform;
            instance.transform.position = startPosition;
            return instance;
        }
    }
}
