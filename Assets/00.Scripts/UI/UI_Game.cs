using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private Slider _fearSlider;
    
    public static UI_Game Instance;

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
        PlayManager.Instance.OnPlayStart += () => gameObject.SetActive(true);
        PlayManager.Instance.OnGameOver += () => gameObject.SetActive(false);
        
        gameObject.SetActive(false);
    }

    public void RefreshScore(int score)
    {
        _scoreText.text = $"{score}M";
    }

    public void RefreshTime(float time)
    {
        _timerText.text = $"{(int)time:00}:{(int)(time * 100) % 100:00}";
    }

    public void InitializeStamina(float maxStamina)
    {
        _staminaSlider.maxValue = maxStamina;
    }

    public void RefreshStamina(float stamina)
    {
        _staminaSlider.value = stamina;
    }

    public void InitializeFear(float maxFear)
    {
        _fearSlider.maxValue = maxFear;
    }

    public void RefreshFear(float fear)
    {
        _fearSlider.value = fear;
    }
}
