using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    // 몬스터를 원하는 위치/시간에 맞춰 생성
    // TODO: 몬스터 풀에서 몬스터 받아서 생성

    [SerializeField] private List<GameObject> _monsterPrefabs;

    [SerializeField] private float _minSpawnRate = 1f;
    [SerializeField] private float _maxSpawnRate = 2f;
    
    [SerializeField] private Vector2 _spawnDirection;

    private float _spawnRate;

    private float _spawnTimer;

    private void Start()
    {
        _spawnRate = 0f;
    }

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer <= _spawnRate) return;

        // 생성
        GameObject monster = Instantiate(_monsterPrefabs[Random.Range(0, _monsterPrefabs.Count)]);
        monster.transform.position = transform.position;

        monster.GetComponent<Monster>().MoveDirection = _spawnDirection;

        _spawnTimer = 0f;
        _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }
}