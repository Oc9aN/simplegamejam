using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    // 게임 오버, 재시작 등을 관리
    public static PlayManager Instance;

    public const float START_HEIGHT = 100f;
    
    public event Action OnGameOver;
    public event Action OnPlayStart;

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
            StartPlay();
    }

    public void GameOver()
    {
        // TODO: 추후 수정
        OnGameOver?.Invoke();
    }

    public void StartPlay()
    {
        OnPlayStart?.Invoke();
    }
}
