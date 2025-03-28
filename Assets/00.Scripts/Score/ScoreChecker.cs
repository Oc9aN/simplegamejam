using System;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    private int _score;

    private int _maxScore;

    private void Update()
    {
        SetScore();
    }

    private void SetScore()
    {
        if (_score != (int)transform.position.y)
        {
            _score = (int)transform.position.y;
            UI_Game.Instance.RefreshScore(_score);
            if (_score > _maxScore)
            {
                _maxScore = _score;
                UI_End.Instance.RefreshScore(_maxScore);
            }
        }
    }
}