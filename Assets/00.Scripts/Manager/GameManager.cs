using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 전체 게임시작을 담당
    
    public static GameManager Instance;
    
    public event Action OnGameStart;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
