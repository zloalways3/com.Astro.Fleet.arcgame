using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicFleet : MonoBehaviour
{

    public Sprite sprite1Fleet;
    public Sprite sprite2Fleet;
    public Sprite sprite3Fleet;
    public Sprite sprite4Fleet;
    public Sprite sprite5Fleet;
    public Sprite sprite6Fleet;
    public Sprite sprite7Fleet;
 

    public System.Random rFleet = new System.Random();
    public int speedFleet;


    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }

    public Text scoreTextFleet;
    private int currentScoreFleet = 0;
    private int goalFleet;
    public int currentDifFleet = 0;


    public void StartGameFleet(int difFleet)
    {
        currentScoreFleet = 0;
        GetComponent<TimerScriptFleet>().RefreshTimerFleet();
        
        GameObject.Find("RocketFleet").GetComponent<RocketMoveFleet>().InitRocketFleet();
        CounterFleet();
        for (int iFleet = 1; iFleet < 14; iFleet++)
        {
            GameObject.Find("ObjectTestFleet"+iFleet).GetComponent<ObjectFleet>().ResetFleet();
        }
        CounterFleet();
        goalFleet = difFleet * 200 + 600;
        currentDifFleet = difFleet;
        CounterFleet();
        scoreTextFleet.text = "Score\n" + currentScoreFleet + "/" + goalFleet;
        

    }
    public void CollisionFleet(bool collisionFleet)
    {
        if (collisionFleet)
        {
            CounterFleet();
            currentScoreFleet += 50;
            scoreTextFleet.text = "Score\n" + currentScoreFleet + "/" + goalFleet;
            GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().PlayPingFleet();
            if (currentScoreFleet>= goalFleet)
            {
                GetComponent<JumpCanvasFleet>().JumpFleet("winFleet");
                GameObject.Find("WinnerCanvasFleet").GetComponent<WinScriptFleet>().WinScreenFleet();
            }
        }
        else
        {
            CounterFleet();
            GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().PlayBoomFleet();
            GetComponent<JumpCanvasFleet>().JumpFleet("loseFleet");
        }

    }


    public Tuple<Sprite, bool> RandomSpriteFleet()
    {
        Sprite tempSpriteFleet;
        int rIntFleet = rFleet.Next(0, 8);
        CounterFleet();
        if (rIntFleet == 0) tempSpriteFleet = sprite1Fleet;
        else if (rIntFleet == 1) tempSpriteFleet = sprite2Fleet;
        else if (rIntFleet == 2) tempSpriteFleet = sprite3Fleet;
        else if (rIntFleet == 3) tempSpriteFleet = sprite4Fleet;
        else if (rIntFleet == 4) tempSpriteFleet = sprite5Fleet;
        else if (rIntFleet == 5) tempSpriteFleet = sprite6Fleet;
        else tempSpriteFleet = sprite7Fleet;
        bool goodFleet = false;
        if(rIntFleet<4)goodFleet = true;
        else goodFleet = false;
        CounterFleet();
        speedFleet = rIntFleet + 3;
        return Tuple.Create(tempSpriteFleet,goodFleet);
    }

}
