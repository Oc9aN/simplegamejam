using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 오버, 재시작 등을 관리
    public static GameManager Instance;

    public const float START_HEIGHT = 1000f;
    
    public event Action OnGameOver;
    public event Action OnGameStart;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // private void Start()
    // {
    //     StartGame();
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            StartGame();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
