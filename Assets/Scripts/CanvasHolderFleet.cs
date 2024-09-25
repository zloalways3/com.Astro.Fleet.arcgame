using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderFleet : MonoBehaviour
{
    public Canvas loadingCanvasFleet;
    public Canvas menuCanvasFleet;
    public Canvas settingsCanvasFleet;
    public Canvas exitCanvasFleet;
    public Canvas gameCanvasFleet;
    public Canvas winCanvasFleet;
    public Canvas loseCanvasFleet;
    public Canvas difChoiceCanvasFleet;


    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }


    public bool activeFleet = true;

    Timer tFleet;

    public Stack<string> currentStackFleet;


    void Start()
    {    
        menuCanvasFleet.enabled = false; 
        settingsCanvasFleet.enabled = false;
        exitCanvasFleet.enabled = false;
         CounterFleet();
        gameCanvasFleet.enabled = false;
        winCanvasFleet.enabled = false;
        difChoiceCanvasFleet.enabled = false;
         CounterFleet();
        loseCanvasFleet.enabled = false;
        currentStackFleet = new Stack<string>();
        currentStackFleet.Push("menuFleet");

        HideTimerFleet();
    }

 
    public void EndLoadFleet()
    {
        CounterFleet();
        loadingCanvasFleet.enabled = false;
        menuCanvasFleet.enabled = true;
    }




    public void HideTimerFleet()
    {
        tFleet = new Timer(1500);
        tFleet.AutoReset = false;
        CounterFleet();
        tFleet.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tFleet.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterFleet();
            EndLoadFleet();
        }
        finally
        {
             CounterFleet();
            tFleet.Enabled = false;
        }
    }

    public void MoveBackFleet()
    {
        currentStackFleet.Pop();
         CounterFleet();
        MoveFleet(currentStackFleet.Peek(), true);
    }
    public void MoveFleet(string destinationFleet, bool backmoveFleet = false, int difFleet =0)
    {

        menuCanvasFleet.enabled = false;
        settingsCanvasFleet.enabled = false;
         CounterFleet();
        exitCanvasFleet.enabled = false;
        gameCanvasFleet.enabled = false;
        loseCanvasFleet.enabled = false;
        winCanvasFleet.enabled = false;
        difChoiceCanvasFleet.enabled = false;

        if (destinationFleet == "winFleet")
        {
            winCanvasFleet.enabled = true;
            backmoveFleet = true;
        }

        if (destinationFleet == "loseFleet")
        {
            loseCanvasFleet.enabled = true;
            backmoveFleet = true;
        }


         CounterFleet();

        if (destinationFleet == "menuFleet")
        {
            menuCanvasFleet.enabled = true;
            activeFleet = false;
        }
        else if (destinationFleet == "settingsFleet")
        {
            settingsCanvasFleet.enabled = true;
        }
        else if (destinationFleet == "levelsFleet")
        {
            difChoiceCanvasFleet.enabled = true;
        }
        else if (destinationFleet == "gameFleet")
        {
             CounterFleet();
            gameCanvasFleet.enabled = true;
            if (!backmoveFleet) gameCanvasFleet.GetComponent<GameLogicFleet>().StartGameFleet(difFleet);
        }
        else if (destinationFleet == "exitFleet")
        {
            exitCanvasFleet.enabled = true;
        }
        if (!backmoveFleet) { currentStackFleet.Push(destinationFleet); }
         CounterFleet();
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackFleet.Count == 1)
                    {
                         CounterFleet();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackFleet();
                    }

                }
            }
            catch (Exception eFleet)
            {

            }
        }
    }


}
