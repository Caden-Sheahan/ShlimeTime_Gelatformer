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
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 0;
            rb.AddForce(mouseDir * speedForceApplied * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 1;
        }
    }

    public void Handle_TimeSlowEvent()
    {
        float tempSpeed = (float)(defaultSpeed * .02);
        speedForceApplied = tempSpeed / Time.fixedDeltaTime;
    }
}
