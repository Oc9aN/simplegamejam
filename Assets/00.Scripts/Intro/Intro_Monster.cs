using System;
using UnityEngine;

public class Intro_Monster : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Intro_Chicken"))
        {
            other.gameObject.GetComponent<Intro_Chicken>().Jump(_jumpForce);
        }
    }
}
