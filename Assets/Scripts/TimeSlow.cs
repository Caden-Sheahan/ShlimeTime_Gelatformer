using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    bool slowTime = false;
    bool speedTime = false;
    bool canSlowDown = true;
    public static Action slowTimeEvent;
    public static Action jetpackSlowTimeEvent;
    float currentTimeScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(canSlowDown)
            {
                canSlowDown = false;
                TimeSlowDown();
            } 
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (slowTime)
        {
            if(Time.timeScale >= 0.2f)
            {
                //currentTimeScale *= .995f;
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();
                Time.timeScale *= .995f;
                Time.fixedDeltaTime *= Time.timeScale;
            }
            else
            {
                slowTime = false;
                Invoke("TimeSpeedUp", 0.5f);
            }
        }

        if (speedTime)
        {
            if (Time.timeScale <= 1)
            {
                //currentTimeScale *= 1.001f;
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();
                Time.timeScale *= 1.05f;
                Debug.Log(Time.fixedDeltaTime);
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
            else
            {
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();
                speedTime = false;
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
                canSlowDown = true;
            }
        }
    }
    void TimeSlowDown()
    {
        //  ZA WARUDO
        slowTime = true;
    }

    void TimeSpeedUp()
    {
        speedTime = true;
    }
}
