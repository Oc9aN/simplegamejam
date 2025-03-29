using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_MobileUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiList;

    private void Awake()
    {
#if !UNITY_ANDROID
        foreach (var ui in _uiList)
        {
            Destroy(ui);
        }
#endif
    }
}