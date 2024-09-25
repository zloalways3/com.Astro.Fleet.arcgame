using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundsFleet : MonoBehaviour
{
    public Sprite onFleet;
    public Sprite offFleet;
    public bool isSoundFleet;
    public bool isOnFleet=true;

    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }
    public void onClickFleet()
    {
        isOnFleet=!isOnFleet;
        CounterFleet();
        if (isSoundFleet) GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().soundIsOnFleet = isOnFleet;
        else GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().musicIsOnFleet = isOnFleet;
        GameObject.Find("MainCameraFleet").GetComponent<SoundManagerFleet>().changedFleet = true;
        if (isOnFleet) GetComponent<Image>().sprite = onFleet;
        else GetComponent<Image>().sprite = offFleet;



    }
}
