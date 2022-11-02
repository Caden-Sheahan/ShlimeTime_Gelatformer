using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 resPos;
    public Rigidbody2D rb;
    float speedForceApplied = 3.0f;
    float defaultSpeed;
    bool lift = false;
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    public GameObject child4;
    public GameObject child5;
    public GameObject child6;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speedForceApplied;
        rb.GetComponent<Rigidbody2D>();
        TimeSlow.slowTimeEvent += Handle_TimeSlowEvent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.x >= 13f || GetComponent<Rigidbody2D>().velocity.y >= 13f)
        {
            GetComponent<Rigidbody2D>().velocity *= 0.95f;
        }
        if (GetComponent<Rigidbody2D>().velocity.x <= -13f || GetComponent<Rigidbody2D>().velocity.y <= -13f)
        {
            GetComponent<Rigidbody2D>().velocity *= 0.95f;
        }

        if(lift)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explode")
        {
            //Pushed player away from the explosion of the first ability
            var force = transform.position - collision.transform.position;
            force.Normalize();
            force *= speedForceApplied;
            //GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + force.x * 10, GetComponent<Rigidbody2D>().velocity.y + force.y* 10);
        }

        if (collision.gameObject.tag == "RespawnPoint")
        {
            //Assigns respawn position
            resPos = collision.transform.position;
            FindObjectOfType<AudioManager>().Play("Checkpoints");
            
        }

        if (collision.CompareTag("Obstacles"))
        {
            //Checks if player collided with an obstacle
            Respawn();
        }
        
        if (collision.CompareTag("Wall"))
        {
            //Play SplatSound1
            FindObjectOfType<AudioManager>().Play("SlimeSplat1");
        }

        if(collision.gameObject.tag == "CrystalLift")
        {
            lift = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CrystalLift")
        {
            lift = false;
        }
    }

    public void Respawn()
    {
        // If you don't touch the checkpoint first, you don't respawn. Ez fix,
        // just wanted to mention it.
        if(resPos != Vector2.zero)
        {
            //Kill player
            gameObject.GetComponent<Swing>().Recall();
            transform.position = resPos;
            rb.velocity = Vector2.zero;
            child1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child4.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child5.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child6.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
    }

    public void Handle_TimeSlowEvent()
    {
        //Adjusts force relative to time
        float tempSpeed = (float)(defaultSpeed * .02);
        //speedForceApplied = tempSpeed / Time.fixedDeltaTime;

        
    }
    public void OnDestroy()
    {
        TimeSlow.slowTimeEvent -= Handle_TimeSlowEvent;
    }

    //Ignore this
    //call from another Class
    //gameObjectVariableName.GetComponent<Codename>.functionCalled
}
