using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TimeSlow : MonoBehaviour
{
    bool slowTime = false;
    bool speedTime = false;
    bool canSlowDown = true;
    public static Action slowTimeEvent;
    public static Action jetpackSlowTimeEvent;

    public GameObject slimeBod;
    public GameObject slimeEyes;
    // Start is called before the first frame update
    void Start()
    {
        slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.yellow;
        slimeEyes.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(canSlowDown)
            {
                //Starts the process of slowing down time
                canSlowDown = false;
                TimeSlowDown();

                slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.yellow;
                slimeEyes.GetComponent<SpriteRenderer>().color = Color.yellow;
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
                //Slows down time until it reaches 1/5 speed
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();

                Time.timeScale *= .995f;
                Time.fixedDeltaTime = 0.02f *Time.timeScale;

            }
            else
            {
                //Time has reached 1/5 speed
                slowTime = false;
                Invoke("TimeSpeedUp", 0.5f);
            }
        }

        if (speedTime)
        {
            if (Time.timeScale <= 1)
            {
                //Speeds up time back to normal
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();
                Time.timeScale *= 1.05f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
            else
            {    
                //Makes sure that time is exactly 1.0
                speedTime = false;
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f;
                canSlowDown = true;
                slowTimeEvent?.Invoke();
                jetpackSlowTimeEvent?.Invoke();
            }
        }
    }
    void TimeSlowDown()
    {
        //  ZA WARUDO
        //Starts the slow down of time
        slowTime = true;
    }

    void TimeSpeedUp()
    {
        //Starts the speed up of time
        speedTime = true;
    }
}
