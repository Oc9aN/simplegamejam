using System;
using TMPro;
using UnityEngine;

public class UI_End : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public static UI_End Instance;

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
}
