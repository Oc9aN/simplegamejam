using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _axisValue;
    [SerializeField] private Sprite _pressedImage;
    
    private Image _image;
    private Sprite _defaultImage;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultImage = _image.sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UIInputManager.Instance.AxisRaw = _axisValue;
        _image.sprite = _pressedImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Mathf.Approximately(UIInputManager.Instance.AxisRaw, _axisValue))
            UIInputManager.Instance.AxisRaw = 0;
        _image.sprite = _defaultImage;
    }
}