using System.Collections;
using UnityEngine;
using System;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float _time;

    public Action getBall;

    void Start()
    {
        UpdateTimeText();
        _time = 0;
    }

    void Update()
    {

    }

    public IEnumerator StartTimer()
    {
        _time = 4f;

        while (_time > 0)
        {
            _time -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }

        getBall?.Invoke();
    }

    private void UpdateTimeText()
    {
        if (_time < 0)
            _time = 0;

        float minutes = Mathf.FloorToInt(_time / 60);
        float seconds = Mathf.FloorToInt(_time % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
