using System;
using UnityEngine;

[RequireComponent(typeof(Chicken))]
public class ChickenComponent : MonoBehaviour
{
    protected Chicken Chicken;

    protected virtual void Awake()
    {
        Chicken = GetComponent<Chicken>();
    }
}
