using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 resPos;
    public Rigidbody2D rb;
    float speedForceApplied = 500;
    float defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speedForceApplied;
        rb.GetComponent<Rigidbody2D>();
        TimeSlow.slowTimeEvent += Handle_TimeSlowEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explode")
        {
            var force = transform.position - collision.transform.position;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * speedForceApplied);
        }

        if (collision.gameObject.tag == "RespawnPoint")
        {
            resPos = collision.transform.position;
        }

        if (collision.CompareTag("Obstacles"))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // If you don't touch the checkpoint first, you don't respawn. Ez fix,
        // just wanted to mention it.
        if(resPos != Vector2.zero)
        {
            transform.position = resPos;
            rb.velocity = Vector2.zero;
        }
        
    }

    public void Handle_TimeSlowEvent()
    {
        float tempSpeed = (float)(defaultSpeed * .02);
        speedForceApplied = tempSpeed / Time.fixedDeltaTime;

        //if (Time.fixedDeltaTime == .02f)
        //{
            //speedForceApplied = 500;
        //}
        //speedForceApplied *= speedRate;
        //Vector2 modifier = rb.velocity * (speedRate-1);
        //rb.velocity = new Vector2(rb.velocity.x + modifier.x, rb.velocity.y + modifier.y);
    }
    
    
    //Ignore this
    //call from another Class
    //gameObjectVariableName.GetComponent<Codename>.functionCalled
}
