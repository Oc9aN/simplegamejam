using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Slider _staminaSlider;
    
    public static UI_Game Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void RefreshScore(int score)
    {
        _scoreText.text = $"{score}M";
    }

    public void InitializeStamina(float maxStamina)
    {
        _staminaSlider.maxValue = maxStamina;
    }

    public void RefreshStamina(float stamina)
    {
        _staminaSlider.value = stamina;
    }
}
