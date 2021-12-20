using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] _enemyPrefabs;
    [SerializeField] Transform[] _spawnPoints;

    [SerializeField] float _respawnRate = 10;
    [SerializeField] float _initialSpawnDelay;

    [SerializeField] int _totalNumberToSpawn;
    [SerializeField] int _numberToSpawnEachTime = 1;

    float _spawnTimer;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
            Spawn();
    }

    private bool ShouldSpawn()
    {
        return _spawnTimer >= _respawnRate;
    }

    private void Spawn()
    {
        _spawnTimer = 0;

        Enemy prefab = ChooseRandomEnemyPrefab();

        if(_enemyPrefabs != null)
        {
            Transform spawnPoint = ChooseRandomSpawnPoint();
            var enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private Transform ChooseRandomSpawnPoint()
    {
        if (_spawnPoints.Length == 0)
            return transform;

        if (_spawnPoints.Length == 1)
            return _spawnPoints[0];

        int index = UnityEngine.Random.Range(0, _enemyPrefabs.Length);

        return _spawnPoints[index];
    }

    private Enemy ChooseRandomEnemyPrefab()
    {
        if (_enemyPrefabs.Length == 0)
            return null;

        if (_enemyPrefabs.Length == 1)
            return _enemyPrefabs[0];

        int index = UnityEngine.Random.Range(0, _enemyPrefabs.Length);

        return _enemyPrefabs[index];
    }
}
