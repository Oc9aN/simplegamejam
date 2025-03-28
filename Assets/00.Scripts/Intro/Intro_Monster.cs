using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Intro_Monster : MonoBehaviour
{
    private MMF_Player _player;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _player = GetComponent<MMF_Player>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Intro_Chicken"))
        {
            _player.PlayFeedbacks();
            other.gameObject.GetComponent<Intro_Chicken>().Jump(_jumpForce);
        }
    }
}