using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Heart : MonoBehaviour
{
    private const float DURATION = 0.2f;
    [SerializeField] private float _defaultHeartTime;
    [SerializeField] private float _heartTime;
    private RectTransform rectTransform;

    private float _heartTimer;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _heartTimer += Time.deltaTime;
        if (FearManager.instance.Fear > FearManager.instance.MaxFear * 0.7f)
        {
            _heartTime = 0.3f;
        }
        else if (FearManager.instance.Fear > FearManager.instance.MaxFear * 0.4f)
        {
            _heartTime = 0.6f;
        }
        else if (FearManager.instance.Fear > FearManager.instance.MaxFear * 0.2f)
        {
            _heartTime = 1f;
        }
        else
        {
            _heartTime = _defaultHeartTime;
        }
        if (_heartTimer >= _heartTime)
        {
            HeartShake();
            _heartTimer = 0f;
        }
    }

    private void HeartShake()
    {
        rectTransform.DOPunchScale(Vector2.one * 1.1f, DURATION, 10, 0.5f);
    }
}