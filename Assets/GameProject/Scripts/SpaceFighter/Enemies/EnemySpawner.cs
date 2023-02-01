using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject(Id = "MeteorPrefub")]
    private GameObject _meteorPrefub;

    [Inject(Id = "EnemiesContainer")]
    private GameObject _enemiesContainer;

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
        var enemy = _container.InstantiatePrefab(_meteorPrefub);
        enemy.transform.parent = _enemiesContainer.transform;
        enemy.transform.position = GetRandomPointInBoxCollider2D();
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
