using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MonsterPool : MonoBehaviour
{
    // 몬스터 프리팹들
    [SerializeField] private Monster _monsterPrefab;
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

        _pool = new List<Monster>(_poolSize);
        for (int i = 0; i < _poolSize; i++)
        {
            Monster monster = Instantiate(_monsterPrefab, transform);
                
            _pool.Add(monster);
                
            // 비활성화
            monster.gameObject.SetActive(false);
        }
    }
    
    public Monster Create(Vector3 position)
    {
        foreach (var monster in _pool)
        {
            if (monster.gameObject.activeInHierarchy == false)
            {
                monster.transform.position = position;
                    
                // monster.Initialize();
                    
                monster.gameObject.SetActive(true);

                return monster;
            }
        }
        return null;
    }

    public void AllDestroy()
    {
        foreach (var monster in _pool)
        {
            monster.gameObject.SetActive(false);
        }
    }
}
