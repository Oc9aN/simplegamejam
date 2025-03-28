using System;
using UnityEngine;

public class FearManager : MonoBehaviour
{
    // 공포도 제어
    public static FearManager instance;

    private float _maxFear;

    public float MaxFear
    {
        get => _maxFear;
        set => _maxFear = value;
    }

    private float _fear;

    public float Fear
    {
        get { return _fear; }
        set
        {
            _fear = value;
            UI_Game.Instance.RefreshFear(_maxFear - _fear);
            // 피어가 넘치면
            if (_fear >= _maxFear)
            {
                Debug.Log("Fear over");
                GameManager.Instance.GameOver();
            }
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        UI_Game.Instance.InitializeFear(_maxFear);
    }
}