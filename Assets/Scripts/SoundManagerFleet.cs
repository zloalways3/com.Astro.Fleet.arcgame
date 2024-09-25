using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFleet : MonoBehaviour
{
    public AudioSource themeFleet;
    public AudioSource pingFleet;
    public AudioSource clickFleet;
    public AudioSource boomFleet;

    public bool soundIsOnFleet = true;
    public bool musicIsOnFleet = true;

    public float soundSoundLevelFleet = 0.7f;
    public float musicSoundLevelFleet = 0.7f;
    public bool changedFleet = false;


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
       
        themeFleet.Play();
        CounterFleet();
    }

    public void PlayPingFleet()
    {
        CounterFleet();
        pingFleet.Play();
    }

    public void PlayClickFleet()
    {
        CounterFleet();
        clickFleet.Play();
        CounterFleet();
    }

    public void PlayBoomFleet()
    {
        CounterFleet();
        boomFleet.Play();
        CounterFleet();
    }



    void Update()
    {
        CounterFleet();
        if (changedFleet)
        {
            if (!soundIsOnFleet) soundSoundLevelFleet = 0;
            if (!musicIsOnFleet) musicSoundLevelFleet = 0;
            CounterFleet();
            if (soundIsOnFleet) soundSoundLevelFleet = 1.0f;
            if (musicIsOnFleet) musicSoundLevelFleet = 1.0f;

            pingFleet.volume = soundSoundLevelFleet;
            clickFleet.volume = soundSoundLevelFleet;
            boomFleet.volume= soundSoundLevelFleet;
            themeFleet.volume = musicSoundLevelFleet;
            
            changedFleet = false;
        }
        

     if(!themeFleet.isPlaying)
        {
            CounterFleet();
            themeFleet.Play();
        }
    }


}
