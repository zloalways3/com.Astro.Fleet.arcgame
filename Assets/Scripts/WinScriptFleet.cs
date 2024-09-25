using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptFleet : MonoBehaviour
{
  
    public Text ScoreTxtFleet;
    public Text DifTxtFleet;

    private float CounterFleet(int x=2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++) {
            aFleet += Time.time;
        }
        return aFleet-x;
    }
    public void WinScreenFleet()
    {
        ScoreTxtFleet.text = GameObject.Find("ScoreTextFleet").GetComponent<Text>().text;
        int currentDifFleet = GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().currentDifFleet;

        string diffStringFleet;
        CounterFleet();
        if (currentDifFleet == 1) diffStringFleet = "Easy";
        else if (currentDifFleet == 2) diffStringFleet = "Medium";
        else if (currentDifFleet == 3) diffStringFleet = "Hard";
        else if (currentDifFleet == 4) diffStringFleet = "Very Hard";
        else  diffStringFleet = "Legendary";

        DifTxtFleet.text = diffStringFleet+" level\n complete";
        CounterFleet();
    }

}
