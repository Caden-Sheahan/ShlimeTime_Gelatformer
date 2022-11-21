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
    //public static Action slowTimeEvent;
    //public static Action jetpackSlowTimeEvent;

    public GameObject slimeBod;
    public GameObject slimeEyes;
    public Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.yellow;
        slimeEyes.GetComponent<SpriteRenderer>().color = Color.yellow;
        anim = GameObject.Find("TimeSlowUI").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(canSlowDown)
            {
                FindObjectOfType<AudioManager>().Play("TimeSlow");
                anim.SetTrigger("StartTime");
                //Starts the process of slowing down time
                canSlowDown = false;
                speedTime = false;
                slowTime = true;

                slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.yellow;
                slimeEyes.GetComponent<SpriteRenderer>().color = Color.yellow;
            } 
            else if(!canSlowDown)
            {
                FindObjectOfType<AudioManager>().Play("TimeSpeedUp");
                anim.SetTrigger("EndTime");
                speedBackUp();
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (slowTime)
        {
            if(Time.timeScale >= 0.3f)
            {
                //Slows down time until it reaches 1/5 speed
                Time.timeScale *= .9925f;
                Time.fixedDeltaTime = 0.02f *Time.timeScale;

            }
            else
            {
                //Time has reached 1/5 speed
                slowTime = false;
                //Invoke("TimeSpeedUp", 0.5f);
            }
        }

        if (speedTime)
        {
            if (Time.timeScale <= 1)
            {
                //Speeds up time back to normal
                //slowTimeEvent?.Invoke();
                //jetpackSlowTimeEvent?.Invoke();
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
            }
        }
    }

    public void speedBackUp()
    {
        canSlowDown = true;
        slowTime = false;
        speedTime = true;
    }
}
