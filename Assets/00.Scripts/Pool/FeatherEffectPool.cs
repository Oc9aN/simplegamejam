using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FeatherEffectPool : MonoBehaviour
{
    // 몬스터 프리팹들
    [SerializeField] private ParticleSystem _featherPrefabs;
    // 풀 사이즈
    [SerializeField] private int _poolSize;
    // 풀
    private List<ParticleSystem> _pool;
    
    // 싱글톤
    public static FeatherEffectPool Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;

        _pool = new List<ParticleSystem>(_poolSize);
        for (int i = 0; i < _poolSize; i++)
        {
            ParticleSystem enemy = Instantiate(_featherPrefabs, transform);
                
            _pool.Add(enemy);
                
            // 비활성화
            enemy.gameObject.SetActive(false);
        }
    }
    
    public ParticleSystem Create(Vector3 position)
    {
        foreach (var featherEffect in _pool)
        {
            if (featherEffect.gameObject.activeInHierarchy == false)
            {
                featherEffect.transform.position = position;
                    
                //featherEffect.Initialize();
                    
                featherEffect.gameObject.SetActive(true);

                return featherEffect;
            }
        }
        return null;
    }

    public void AllDestroy()
    {
        foreach (var featherEffect in _pool)
        {
            featherEffect.gameObject.SetActive(false);
        }
    }
}
