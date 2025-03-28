using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float _threshold;
    [SerializeField] private float _jumpPadForce;

    private Vector2 _moveDirection = Vector2.zero;

    private MMF_Player _player;

    public Vector2 MoveDirection
    {
        get => _moveDirection;
        set
        {
            _moveDirection = value;
            SetSpriteFlip(_moveDirection);
        }
    }

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<MMF_Player>();
    }

    // 충돌 계산
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Vector2 up = transform.up;
        Vector2 targetDirection = (other.transform.position - transform.position).normalized;

        float dot = Vector3.Dot(up, targetDirection);

        if (dot > _threshold)
        {
            // 같은 방향이므로 점프
            other.gameObject.GetComponent<ChickenMove>().Jump(_jumpPadForce);
            _player.PlayFeedbacks();
        }
    }

    private void SetSpriteFlip(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}