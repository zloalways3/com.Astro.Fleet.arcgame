using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketMoveFleet : MonoBehaviour
{

    private float limitFleet = 40;
    private float currentPosFleet = 0;
    public Vector3 rocketPositionFleet;

     private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }
    public void InitRocketFleet()
    {
        //currentPosFleet = 0;
        rocketPositionFleet = transform.localPosition;
    }
    public void TransitionFleet(Boolean rightFleet)
    {

        float moveFleet = 10;
        if (!rightFleet)
        {
            CounterFleet();
            moveFleet *= (-1);
            if (currentPosFleet > -limitFleet) currentPosFleet--;
        }
        else if (currentPosFleet < 50) currentPosFleet++;

        if (System.Math.Abs(currentPosFleet) < limitFleet)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + moveFleet, transform.localPosition.y, transform.localPosition.z);
            rocketPositionFleet = transform.localPosition;
        }

    }
}

