using System;
using System.Collections;
using UnityEngine;

public class Intro_Chicken : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _target;

    private Coroutine _moveCoroutine;

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
        Debug.Log("Velocity Changed");
        _rigidbody2D.linearVelocityX = 1f;
        Debug.Log(_rigidbody2D.linearVelocityX);

        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
        _moveCoroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Debug.Log("Coroutine Started");
        Debug.Log(Mathf.Abs(_target.position.x - transform.position.x));
        while (Mathf.Abs(_target.position.x - transform.position.x) > 0.1f)
        {
            yield return null;
        }
        Debug.Log("Moved");
        _rigidbody2D.linearVelocityX = 0f;
        yield break;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}