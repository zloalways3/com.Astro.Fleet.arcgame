using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptFleet : MonoBehaviour
{
    public float TimeLeftFleet = 120;
    public bool TimerOnFleet = false;


    public Text TimerTxtFleet;



    void Update()
    {
        if (TimerOnFleet)
        {
            if (TimeLeftFleet > 1)
            {
                TimeLeftFleet -= Time.deltaTime;
                UpdateTimerFleet(TimeLeftFleet);
            }
            else
            {
                GameObject.Find("MainCameraFleet").GetComponent<CanvasHolderFleet>().MoveFleet("loseFleet");
            }
        }
    }

    public void RefreshTimerFleet()
    {
        TimeLeftFleet = 120;
        TimerOnFleet = true;
        TimerTxtFleet.text = "";
    }
    void UpdateTimerFleet(float currentTimeFleet)
    {
        currentTimeFleet -= 1;

        float minutesFleet = Mathf.FloorToInt(currentTimeFleet / 60);
        float secondsFleet = Mathf.FloorToInt(currentTimeFleet % 60);

        TimerTxtFleet.text = "Time:\n" + string.Format("{0:00}:{1:00}", minutesFleet, secondsFleet);
    }
}
