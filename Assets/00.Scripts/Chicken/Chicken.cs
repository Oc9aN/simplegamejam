using System;
using UnityEngine;

public enum ChickenState
{
    Good, // 공포 회복
    Gliding, // 약간 공포 증가
    Fall, // 공포 증가
}
// 데이터를 담당
public class Chicken : MonoBehaviour
{
    // 스테미나
    [Header("STAMINA")] [SerializeField] private float _maxStamina;
    [SerializeField] private float _staminaRecoveryRate; // 스테미나 회복 속도

    [Header("FEAR")] [SerializeField] private float _maxFear;
    [SerializeField] private float _fearRecoverRate;
    [SerializeField] private float _fearGainRate;
    
    public event Action<ChickenState> OnStateChange;

    private ChickenState _chickenState;

    public ChickenState ChickenState
    {
        get => _chickenState;
        set
        {
            if (_chickenState == value) return;
            
            _chickenState = value;
            OnStateChange?.Invoke(_chickenState);
        }
    }

    private float _stamina;

    private float Fear
    {
        get { return FearManager.instance.Fear; }
        set { FearManager.instance.Fear = value; }
    }

    public float Stamina
    {
        get => _stamina;
        set
        {
            _stamina = value;
            UI_Game.Instance.RefreshStamina(_stamina);
        }
    }

    private void Start()
    {
        // 맥스 피어 설정
        FearManager.instance.MaxFear = _maxFear;

        UI_Game.Instance.InitializeStamina(_maxStamina);
        Stamina = _maxStamina;
    }

    private void Update()
    {
        StaminaRecovery();
        FearControl();
    }

    private void StaminaRecovery()
    {
        if (Stamina < _maxStamina)
        {
            Stamina += _staminaRecoveryRate * Time.deltaTime;
        }
    }

    private void FearControl()
    {
        switch (_chickenState)
        {
            case ChickenState.Good:
                if (Fear > 0)
                {
                    Fear -= _fearRecoverRate * Time.deltaTime;
                }
                break;
            case ChickenState.Gliding:
                Fear += _fearGainRate / 2f * Time.deltaTime;
                break;
            case ChickenState.Fall:
                Fear += _fearGainRate * Time.deltaTime;
                break;
        }
    }
}