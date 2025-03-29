using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_PressedActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent _pressedEvent;
    [SerializeField] private Sprite _pressedImage;

    private Image _image;
    private Sprite _defaultImage;
    private bool _isPressed;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultImage = _image.sprite;
    }

    private void Update()
    {
        if (_isPressed)
        {
            _pressedEvent?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        _image.sprite = _pressedImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        _image.sprite = _defaultImage;
    }
}