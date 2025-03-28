using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Chicken _target;
    [SerializeField] private Vector2 _margin;
    
    private Vector2 _defaultPosition;

    private void Awake()
    {
        _defaultPosition = transform.position;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStart += () => transform.position = _defaultPosition;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_target.gameObject.activeInHierarchy || _target.ChickenState == ChickenState.Death) return;
        // y축만 타겟 따라 이동
        Vector2 newPosition = _target.transform.position;
        newPosition.x = transform.position.x;
        newPosition += _margin;
        transform.position = newPosition;
    }
}