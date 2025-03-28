using System;
using System.Collections;
using UnityEngine;

public class Intro_Chicken : MonoBehaviour
{
    private const string Y_VELOCITY = "YVelocity";
    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _target;

    private Rigidbody2D _rigidbody2D;

    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(Y_VELOCITY, _rigidbody2D.linearVelocityY);
    }

    public void Jump(float jumpForce)
    {
        _rigidbody2D.linearVelocityY = jumpForce;
    }

    public void ChickenIntroJumpEvent()
    {
        _rigidbody2D.gravityScale = 1f;
        Jump(_jumpForce);
        _rigidbody2D.linearVelocityX = 1f;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (Mathf.Abs(_target.position.x - transform.position.x) > 0.1f)
        {
            yield return null;
        }

        _rigidbody2D.linearVelocityX = 0f;
        yield break;
    }

    private void OnDisable()
    {
        _rigidbody2D.gravityScale = 0f;
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}