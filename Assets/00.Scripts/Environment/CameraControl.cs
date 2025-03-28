using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector2 _margin;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_target.activeInHierarchy) return;
        // y축만 타겟 따라 이동
        Vector2 newPosition = _target.transform.position;
        newPosition.x = transform.position.x;
        newPosition += _margin;
        transform.position = newPosition;
    }
}