using System;
using TMPro;
using UnityEngine;

public class UI_End : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeText;
    
    public static UI_End Instance;

    private int _recordHeight;
    public int RecordHieght {private get => _recordHeight; set => _recordHeight = value; }
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Start()
    {
        PlayManager.Instance.OnGameOver += () => gameObject.SetActive(true);
        GameManager.Instance.OnGameStart += () => gameObject.SetActive(false);
        
        gameObject.SetActive(false);
    }
    
    public void RefreshScore(int score)
    {
        _scoreText.text = $"SCORE: {score}M";
    }

    public void RefreshTime(float time)
    {
        _timeText.text = $"{_recordHeight}M TIME: {(int)time:00}:{(int)(time * 100) % 100:00}";
    }
}
