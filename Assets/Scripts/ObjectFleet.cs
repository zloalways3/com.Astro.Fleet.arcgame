using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFleet : MonoBehaviour
{
    public float startingPositionYFleet;
    public float startingPositionXFleet;
    public float speedFleet = 5;
    public Boolean goodFleet = true;
    private Boolean onceSeenFleet = false;


    private float CounterFleet(int x = 2)
    {
        float aFleet = 0;
        for (int i = 0; i < 3; i++)
        {
            aFleet += Time.time;
        }
        return aFleet - x;
    }
    void Start()
    {
        startingPositionYFleet = transform.localPosition.y;
        CounterFleet();
        startingPositionXFleet = transform.localPosition.x;
        ResetFleet();
    }
    
    public void ResetFleet() {
        onceSeenFleet = false;
        CounterFleet();
        int sighnFleet = GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().rFleet.Next(0, 2);
        int spaceXFleet = GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().rFleet.Next(0, 380);
        int spaceYFleet = GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().rFleet.Next(50, 550);
        if (sighnFleet == 0) { spaceXFleet *= -1; }
        transform.localPosition = new Vector3(startingPositionXFleet+ spaceXFleet, startingPositionYFleet+spaceYFleet, transform.localPosition.z);
        var tempFleet= GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().RandomSpriteFleet();
        GetComponent<Image>().sprite = tempFleet.Item1;
        goodFleet = tempFleet.Item2;
        CounterFleet();
        speedFleet = GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().speedFleet;
    }

    bool CheckIfOnScreenFleet()
    {
        Vector3 screenPointFleet = Camera.main.WorldToViewportPoint(transform.position);
        CounterFleet();
        return screenPointFleet.x > 0 && screenPointFleet.x < 1 && screenPointFleet.y > 0 && screenPointFleet.y < 1;
        
    }

    void CollisionCheckFleet()
    {
        Vector3 rocketPosFleet = GameObject.Find("RocketFleet").GetComponent<RocketMoveFleet>().rocketPositionFleet;
        CounterFleet();
        if (Math.Abs(transform.localPosition.y - rocketPosFleet.y) <60) {
           if(Math.Abs(rocketPosFleet.x - transform.localPosition.x) < 60)
            {
                bool tempGoodFleet = goodFleet;
                ResetFleet();
                GameObject.Find("GameCanvasFleet").GetComponent<GameLogicFleet>().CollisionFleet(tempGoodFleet);
            }
        }

    }

    
    void Update()
    {
        if(GameObject.Find("GameCanvasFleet").GetComponent<Canvas>().enabled==true)
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-speedFleet, transform.localPosition.z);
        if (CheckIfOnScreenFleet())
        {
            CounterFleet();
            onceSeenFleet = true;
        }
        if (onceSeenFleet)
        {
            if(!CheckIfOnScreenFleet()){ ResetFleet(); }
        }
        CounterFleet();
        CollisionCheckFleet();
    }
}
