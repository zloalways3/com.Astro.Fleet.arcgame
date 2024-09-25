using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasFleet : MonoBehaviour
{

    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }


    public void JumpFleet(string destinationFleet)
    {
        CounterFleet();
        GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().PlayClickFleet();
        GameObject.Find("MainCameraFleet").GetComponent<CanvasHolderFleet>().MoveFleet(destinationFleet,false);
    }

    public void JumpFleetGame(int difFleet)
    {
        CounterFleet();
        GameObject.Find("MainCameraFleet").GetComponent<CanvasHolderFleet>().MoveFleet("gameFleet", false,difFleet);
    }


    public void JumpBackFleet()
    {
        GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().PlayClickFleet();
        CounterFleet();
        GameObject.Find("MainCameraFleet").GetComponent<CanvasHolderFleet>().MoveBackFleet();
       
    }

    public void CloseFleet()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterFleet();
        activity.Call<bool>("moveTaskToBack", true);
    }
}
