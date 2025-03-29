using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Monster))]
public class MonsterMove : MonoBehaviour
{
    // 몬스터 움직임 제어
    // 포물선 움직임

    [Header("JUMP")]
    [SerializeField] private float _jumpMultiplier = 1f;
    
    // 점프력
    [SerializeField] private float _jumpForceMin = 5f;
    [SerializeField] private float _jumpForceMax = 10f;
    
    [Header("FALL")]
    // 추락 계수
    [SerializeField] private float _fallMultiplier = 2f;
    
    [Header("MOVE")]
    // 이동력
    [SerializeField] private float _moveForceMin = 3f;
    [SerializeField] private float _moveForceMax = 5f;
    
    // 이동 방향
    private Monster _monster;
    private Vector2 _moveDirection = Vector2.zero;
    
    private Rigidbody2D _rigidbody2D;
    
    private Vector2 _gravity;

    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _gravity = new Vector2(0f, -Physics.gravity.y);
    }

    private void Start()
    {
        _moveDirection = _monster.MoveDirection;
        Appear();
    }

    private void OnEnable()
    {
        _moveDirection = _monster.MoveDirection;
        Appear();
    }

    private void Update()
    {
        CalculateGravity();
        JumpMultiply();
    }

    private void Appear()
    {
        float jumpForce = Random.Range(_jumpForceMin, _jumpForceMax);
        float moveForce = Random.Range(_moveForceMin, _moveForceMax);
        
        _moveDirection.Normalize();
        _rigidbody2D.AddForce(_moveDirection *  moveForce, ForceMode2D.Impulse);

        _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpForce);
    }
    
    private void CalculateGravity()
    {
        _rigidbody2D.linearVelocity -= _gravity * (_fallMultiplier * Time.deltaTime);
    }

    private void JumpMultiply()
    {
        if (_rigidbody2D.linearVelocity.y > 0)
        {
            _rigidbody2D.linearVelocity += _gravity * (_jumpMultiplier * Time.deltaTime);
        }
    }
}