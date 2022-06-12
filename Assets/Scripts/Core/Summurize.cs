using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summurize : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject timer;
    private string time;
    [SerializeField] private Text showTime;
    [SerializeField] private GameObject summarize;

    private void Start()
    {
        spawnManager.GetComponent<WaveSpawner>().ShowStatistics += Summit;
     }

    private void TurnOffCanvas()
    {
        Time.timeScale = 0f;
        canvas.SetActive(false);
        summarize.SetActive(true);
    }

    private void SetTime()
    {
        time = timer.GetComponent<TimeCounter>().timeText;
        showTime.text = "Czas ukoñczenia poziomu: " + time;
    }

    private void Summit()
    {
        TurnOffCanvas();
        SetTime();
    }
}
