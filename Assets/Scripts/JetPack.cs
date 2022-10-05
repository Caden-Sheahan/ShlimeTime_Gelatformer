using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    Rigidbody2D rb;
    float speedForceApplied = 75;
    float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speedForceApplied;
        rb = GetComponent<Rigidbody2D>();
        TimeSlow.jetpackSlowTimeEvent += Handle_TimeSlowEvent;
    }

    // Update is called once per frame
    void Update()
    {
        //Finds the direction the player needs to move
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        
        if (Input.GetKey(KeyCode.S))
        {
            //Makes gravity 0 while using ability
            rb.gravityScale = 0;
            //Applies force towards the mouse
            rb.AddForce(mouseDir * speedForceApplied * Time.deltaTime);
            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //Restores gravity
            rb.gravityScale = 1;
        }
    }

    public void Handle_TimeSlowEvent()
    {
        //Adjusts force applied relative to speed
        float tempSpeed = (float)(defaultSpeed * .02);
        speedForceApplied = tempSpeed / Time.fixedDeltaTime;
    }

    public void OnDestroy()
    {
        TimeSlow.jetpackSlowTimeEvent -= Handle_TimeSlowEvent;
    }
}
