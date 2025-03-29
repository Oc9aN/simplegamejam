using System;
using UnityEngine;

public class ChickenMove : ChickenComponent
{
    // 닭의 움직임 제어
    private const float JUMP_FORCE = 10f;
    private const float MAX_Y_VELOCITY = -15f;
    [Header("JUMP")] [SerializeField] private float _jumpMultiplier = 1f; // 점프 계수

    [Header("MOVE")] [SerializeField] private float _moveSpeed = 10f; // 좌우 이동속도

    [Header("FALL")] [SerializeField] private float _fallMultiplier = 2f; // 낙하 계수
    [Header("STAMP")] [SerializeField] private float _stampForce = 20f; // 찍기 힘
    [SerializeField] private float _stampRecoverForce = 5f; // 찍기후 가속 회복

    [Header("Gliding")] [SerializeField] private float _glidingForce = 1f; // 활공 힘
    [SerializeField] private float _glidingMaxVelocity = -3f; // 활공시 최대로 낮아지는 속도
    [SerializeField] private float _glidingStamina = 0.5f; // 활공시 소모 스테미너

    [SerializeField] private DynamicJoystick _joystick;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _gravity;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _gravity = new Vector2(0f, -Physics2D.gravity.y); // 양수값으로 저장

#if !UNITY_ANDROID
        Destroy(_joystick.gameObject);
#endif
    }

    private void Start()
    {
        Chicken.OnPlayStart += () => Jump(JUMP_FORCE, false);
    }

    private void Update()
    {
        if (Chicken.ChickenState == ChickenState.Death) return;

        if (Input.GetKey(KeyCode.Space))
        {
            OnGliding();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rigidbody2D.AddForce(Vector2.down * _stampForce, ForceMode2D.Impulse);
        }

        Move();

        CalculateGravity();
    }

    public void Jump(float force = JUMP_FORCE, bool showEffect = true)
    {
        if (Chicken.ChickenState == ChickenState.Death) return;

        if (showEffect)
        {
            FeatherEffectPool.Instance.Create(transform.position);
            Chicken.PlayJumpSfx();
        }

        _rigidbody2D.linearVelocityY = force;
    }

    private void Move()
    {
        var moveInput = Input.GetAxisRaw("Horizontal");

#if UNITY_ANDROID
        moveInput = _joystick.Horizontal;
#endif

        if (moveInput != 0)
        {
            Chicken.FlipX(moveInput > 0);
        }

        // TODO: 가속도로 이동하게
        _rigidbody2D.linearVelocityX = moveInput * _moveSpeed;
    }

    private void CalculateGravity()
    {
        // 점프중엔 회복
        if (_rigidbody2D.linearVelocity.y > 0)
        {
            Chicken.ChickenState = ChickenState.Good;
        }

        if (_rigidbody2D.linearVelocity.y < 0)
        {
            _rigidbody2D.linearVelocity -= _gravity * (_fallMultiplier * Time.deltaTime);
            // 글라이딩이 아니면 추락중
            if (Chicken.ChickenState != ChickenState.Gliding)
            {
                Chicken.ChickenState = ChickenState.Fall;
            }
        }

        // Y 가속도 제한
        if (_rigidbody2D.linearVelocity.y < MAX_Y_VELOCITY)
        {
            _rigidbody2D.linearVelocity += _gravity * (_stampRecoverForce * Time.deltaTime);
            //_rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, MAX_Y_VELOCITY);
        }
    }

    private void OnGliding()
    {
        // 활공 : _glidingMaxVelocity보다 더 느려질수는 없음
        if (Chicken.Stamina <= 0) return;

        if (_rigidbody2D.linearVelocity.y < 0)
        {
            Chicken.ChickenState = ChickenState.Gliding;
            Chicken.Stamina -= _glidingStamina * Time.deltaTime;
            // 제한 아래보다 Y 가속도가 붙은 경우만 느리게
            if (_rigidbody2D.linearVelocity.y < _glidingMaxVelocity)
            {
                _rigidbody2D.linearVelocity += _gravity * (_glidingForce * Time.deltaTime);
            }
        }
    }
}