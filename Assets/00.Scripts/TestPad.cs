using System;
using UnityEngine;

public class TestPad : MonoBehaviour
{
    // 점프 테스트용
    public float jumpForce = 20f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ChickenMove>().Jump(jumpForce);
        }
    }
}