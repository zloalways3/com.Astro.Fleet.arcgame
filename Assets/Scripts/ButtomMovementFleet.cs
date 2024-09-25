using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtomMovementFleet : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool rightFleet;
    public bool isPressedFleet;

    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressedFleet)
        {          
            OnClickFleet();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressedFleet = true;
        CounterFleet();
    }
    public void OnPointerUp(PointerEventData data)
    {
        CounterFleet();
        isPressedFleet = false;
    }
    public void OnClickFleet()
    {
            GameObject.Find("RocketFleet").GetComponent<RocketMoveFleet>().TransitionFleet(rightFleet);    
    }
}
