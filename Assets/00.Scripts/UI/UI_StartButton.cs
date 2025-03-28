using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(GameManager.Instance.StartGame);
    }
}
