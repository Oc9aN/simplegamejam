using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MonsterPool : MonoBehaviour
{
    // 몬스터 프리팹들
    [SerializeField] private List<Monster> _monsterPrefabs;
    // 풀 사이즈
    [SerializeField] private int _poolSize;
    // 풀
    private List<Monster> _pool;
    
    // 싱글톤
    public static MonsterPool Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        int enemyPrefabCount = _monsterPrefabs.Count;
        _pool = new List<Monster>(enemyPrefabCount * _poolSize);
        foreach (var enemyPrefab in _monsterPrefabs)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                Monster enemy = Instantiate(enemyPrefab, transform);
                
                _pool.Add(enemy);
                
                // 비활성화
                enemy.gameObject.SetActive(false);
            }
        }
    }
    
    public Monster Create(Vector3 position)
    {
        foreach (var enemy in _pool)
        {
            if (enemy.gameObject.activeInHierarchy == false)
            {
                enemy.transform.position = position;
                    
                // enemy.Initialize();
                    
                enemy.gameObject.SetActive(true);

                return enemy;
            }
        }
        return null;
    }

    public void AllDestroy()
    {
        foreach (var enemy in _pool)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
