using System;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    [SerializeField] private bool _removeRecord = false;
    [SerializeField] private int _recordHeight;
    private float _timer;

    private int _score;

    private int _maxScore;

    private float _recordTime;

    private void Start()
    {
        PlayManager.Instance.OnPlayStart += () => _timer = 0;
        UI_End.Instance.RecordHieght = _recordHeight;

        if (_removeRecord)
        {
            PlayerPrefs.DeleteAll();
        }

        LoadRecord();
    }

    private void Update()
    {
        SetTimer();
        SetScore();
    }

    private void SetTimer()
    {
        _timer += Time.deltaTime;
        UI_Game.Instance.RefreshTime(_timer);
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

            if (_score >= _recordHeight && _recordTime < _timer)
            {
                _recordTime = _timer;
                SaveRecord();
                UI_End.Instance.RefreshTime(_recordTime);
            }
        }
    }

    private void SaveRecord()
    {
        PlayerPrefs.SetFloat("RecordTime", _recordTime);
    }

    private void LoadRecord()
    {
        _recordTime = PlayerPrefs.GetFloat("RecordTime", 0);
        UI_End.Instance.RefreshTime(_recordTime);
    }
}