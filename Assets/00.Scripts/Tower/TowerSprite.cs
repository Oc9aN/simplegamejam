
using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerSprite : MonoBehaviour
{
    private float _scrollValue;
    private float _lowerPosition;
    
    private Camera _camera;

    private float _imageHeight;

    private void Awake()
    {
        _camera = Camera.main;
        
        _imageHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        _scrollValue = _imageHeight * 5f;
        _scrollValue = Mathf.Floor(_scrollValue * 10f) / 10f;
        // Debug.Log(_scrollValue);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float lowerY = _camera.WorldToViewportPoint(transform.position).y;
        if (lowerY > 1)
        {
            // 위로 나간 경우 이미지 위치 이동
            transform.position = new Vector2(transform.position.x, transform.position.y - _scrollValue);
        }

        Vector2 upperPosition = transform.position;
        upperPosition.y += _imageHeight;
        float upperY = _camera.WorldToViewportPoint(upperPosition).y;
        if (upperY < 0)
        {
            // 아래로 나간 경우 이미지 위치 이동
            transform.position = new Vector2(transform.position.x, transform.position.y + _scrollValue);
        }
    }
}
