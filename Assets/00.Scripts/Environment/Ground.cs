using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 게임 오버
            PlayManager.Instance.GameOver();
        }
    }
}