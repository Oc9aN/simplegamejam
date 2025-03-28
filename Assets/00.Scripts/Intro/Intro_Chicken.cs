using System;
using System.Collections;
using UnityEngine;

public class Intro_Chicken : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _target;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump(float jumpForce)
    {
        _rigidbody2D.linearVelocityY = jumpForce;
    }

    public void ChickenIntroJumpEvent()
    {
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

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}