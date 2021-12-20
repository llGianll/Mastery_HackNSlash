using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    int _totalNumberSpawned;

    private void OnEnable()
    {
        _spawnTimer = _respawnRate - _initialSpawnDelay;
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (ShouldSpawn())
            Spawn();
    }

    private bool ShouldSpawn()
    {
        if (_totalNumberSpawned >= _totalNumberToSpawn && _totalNumberToSpawn > 0)
            return false;

        return _spawnTimer >= _respawnRate;
    }

    private void Spawn()
    {
        _spawnTimer = 0;

        var availableSpawnPoints = _spawnPoints.ToList();

        for (int i = 0; i < _numberToSpawnEachTime; i++)
        {
            if (_totalNumberSpawned >= _totalNumberToSpawn && _totalNumberToSpawn > 0)
                break;

            Enemy prefab = ChooseRandomEnemyPrefab();

            if (_enemyPrefabs != null)
            {
                Transform spawnPoint = ChooseRandomSpawnPoint(availableSpawnPoints);

                if (availableSpawnPoints.Contains(spawnPoint))
                    availableSpawnPoints.Remove(spawnPoint);

                var enemy = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
                _totalNumberSpawned++;
            }
        }


    }

    private Transform ChooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
    {
        if (availableSpawnPoints.Count == 0)
            return transform;

        if (availableSpawnPoints.Count == 1)
            return availableSpawnPoints[0];

        int index = UnityEngine.Random.Range(0, availableSpawnPoints.Count);

        return availableSpawnPoints[index];
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
