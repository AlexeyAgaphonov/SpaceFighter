using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject(Id = "MeteorPrefub")]
    private GameObject _meteorPrefub;

    [Inject]
    private DI.EnemyFactory _enemyFactory;

    private float _spawnTimer = 0f;

    [SerializeField]
    private float _spawnCooldown = 2f;

    private BoxCollider2D _spawnArea;
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    private void Awake()
    {
        _spawnArea = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandleTimer();
    }

    private void HandleTimer()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnCooldown)
        {
            _spawnTimer = 0f;
            SpawnEnemy(_meteorPrefub);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefub)
    {
        _enemyFactory.Create(_meteorPrefub, GetRandomPointInBoxCollider2D());
    }

    public Vector2 GetRandomPointInBoxCollider2D()
    {
        Vector2 size = _spawnArea.size;
        Vector2 center = (Vector2)_spawnArea.transform.position + _spawnArea.offset;
        Vector2 randomPoint = center + new Vector2(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y
        );

        return randomPoint;
    }
}
