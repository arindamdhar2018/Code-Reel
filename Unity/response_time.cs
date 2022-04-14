using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class response_time : MonoBehaviour
{
    public float currentTime;
    public Text displayTime;
    public bool stopwatchactive = false;
    public string responseTime;
    public float GlobalcurrentTime;
    public Text GlobaldisplayTime;
    public bool Globalstopwatchactive = false;
    public string GlobalresponseTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        GlobalcurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchactive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        displayTime.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        responseTime = time.Minutes + ":" +time.Seconds;


        if (Globalstopwatchactive == true)
        {
            GlobalcurrentTime = GlobalcurrentTime + Time.deltaTime;
        }
         
        TimeSpan Globaltime = TimeSpan.FromSeconds(GlobalcurrentTime);
        GlobaldisplayTime.text = Globaltime.Minutes.ToString() + ":" + Globaltime.Seconds.ToString();
        GlobalresponseTime = Globaltime.Minutes + ":" + Globaltime.Seconds;
    }

    public void startStopWatch()
    {
        stopwatchactive = true;
    }

    public void stopStopWatch()
    {
        stopwatchactive = false;
    }

    public void GlobalstartStopWatch()
    {
        Globalstopwatchactive = true;
    }

    public void GlobalstopStopWatch()
    {
        Globalstopwatchactive = false;
    }
}
