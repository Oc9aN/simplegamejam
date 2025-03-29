using System;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    public static UIInputManager Instance;
    
    private float _axisRaw;
    public float AxisRaw { get { return _axisRaw; } set { _axisRaw = value; } }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
}
