using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Intro_Control : MonoBehaviour
{
    private MMF_Player _player;

    private void Awake()
    {
        _player = GetComponent<MMF_Player>();
    }

    public void StartIntro()
    {
        gameObject.SetActive(true);
        _player.PlayFeedbacks();
    }

    public void EndIntro()
    {
        gameObject.SetActive(false);
    }
}