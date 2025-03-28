using System;
using UnityEngine;

public class UI_Start : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnGameStart += () => gameObject.SetActive(false);
    }
}
