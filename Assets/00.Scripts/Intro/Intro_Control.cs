using MoreMountains.Feedbacks;
using UnityEngine;

public class Intro_Control : MonoBehaviour
{
    [SerializeField] private MMF_Player _player;

    public void StartIntro()
    {
        _player.PlayFeedbacks();
    }
}
