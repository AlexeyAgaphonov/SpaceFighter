using SpaceFighter;
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
            var instance = _container.InstantiatePrefab(prefub, _enemiesContainer.transform);
            instance.transform.position = startPosition;
            var controller = instance.transform.Find("Controller");
            var movingComponent = controller.GetComponent<SpaceFighter.MovingController>();
            movingComponent.Initialize(5f + Random.Range(0f, 1f));
            return instance;
        }
    }
}
