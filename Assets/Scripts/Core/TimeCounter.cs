using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text counterTime;
    public string timeText;

    // Start is called before the first frame update
    void Update()
    {
        float currentTime = Time.time;
        int minutes = (int)currentTime / 60;
        int seconds = (int)currentTime % 60;
        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        counterTime.text = timeText.ToString();
    }

  
 
}
