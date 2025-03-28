using System;
using UnityEngine;

public class ChickenAnimation : ChickenComponent
{
    private const string Y_VELOCITY = "YVelocity";
    private const string GLIDING = "Gliding";
    private const string DEATH = "Death";

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Debug.Log(Chicken);
        Chicken.OnStateChange += TraceGliding;

        GameManager.Instance.OnGameOver += () => SetDeath(true);
        GameManager.Instance.OnGameStart += () => SetDeath(false);
    }

    private void Update()
    {
        if (Chicken.ChickenState == ChickenState.Death) return;
        TraceYVelocity();
    }

    private void TraceYVelocity()
    {
        _animator.SetFloat(Y_VELOCITY, _rigidbody2D.linearVelocityY);
    }

    private void TraceGliding(ChickenState state)
    {
        _animator.SetBool(GLIDING, state == ChickenState.Gliding);
    }

    private void SetDeath(bool value)
    {
        if (value)
        {
            Chicken.ChickenState = ChickenState.Death;
        }
        _animator.SetBool(DEATH, value);
    }
}