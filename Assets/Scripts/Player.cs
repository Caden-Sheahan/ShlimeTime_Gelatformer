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
    Vector2 childLoc1;
    Vector2 childLoc2;
    Vector2 childLoc3;
    Vector2 childLoc4;
    Vector2 childLoc5;
    Vector2 childLoc6;
    bool canPushed = true;
    // Start is called before the first frame update
    void Start()
    {
        //defaultSpeed = speedForceApplied;
        rb.GetComponent<Rigidbody2D>();
        //TimeSlow.slowTimeEvent += Handle_TimeSlowEvent;

        //finds the position of the children relative to the player
        childLoc1 = child1.transform.localPosition;
        childLoc2 = child2.transform.localPosition;
        childLoc3 = child3.transform.localPosition;
        childLoc4 = child4.transform.localPosition;
        childLoc5 = child5.transform.localPosition;
        childLoc6 = child6.transform.localPosition;

        //Places the player at the location saved in Json
        transform.position = JsonManager.instance.GSD.resetPos;
    }

    private void Update()
    {
        //Resets player on demand
        if(Input.GetKeyDown(KeyCode.R))    
        {
            Respawn();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Speed cap
        if (GetComponent<Rigidbody2D>().velocity.x >= 13f || GetComponent<Rigidbody2D>().velocity.y >= 13f)
        {
            GetComponent<Rigidbody2D>().velocity *= 0.95f;
        }
        if (GetComponent<Rigidbody2D>().velocity.x <= -13f || GetComponent<Rigidbody2D>().velocity.y <= -13f)
        {
            GetComponent<Rigidbody2D>().velocity *= 0.95f;
        }

        //Moves player up in the crystal cave lift
        if(lift)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explode")
        {
            if(canPushed)
            {
                canPushed = false;
                Invoke("allowPush", .2f);
                //Pushed player away from the explosion of the first ability
                var force = transform.position - collision.transform.position;
                force.Normalize();
                force *= speedForceApplied;
                //GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + force.x * 20, GetComponent<Rigidbody2D>().velocity.y + force.y* 20);

            }
            
            
        }

        if (collision.gameObject.tag == "RespawnPoint")
        {
            //Assigns respawn position
            resPos = collision.transform.position;
            FindObjectOfType<AudioManager>().Play("Checkpoints");
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //Saves position in Json to use if the player quits
            JsonManager.instance.SavePos(resPos);


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
            //Brings back the swing on death
            gameObject.GetComponent<Swing>().Recall();
            //Reset to checkpoint
            transform.position = resPos;
            //Makes velocity 0
            rb.velocity = Vector2.zero;
            //Makes the child velocity 0
            child1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child4.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child5.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            child6.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Resets position of the children relative to player
            //Prevents deformed player
            child1.transform.localPosition = childLoc1;
            child2.transform.localPosition = childLoc2;
            child3.transform.localPosition = childLoc3;
            child4.transform.localPosition = childLoc4;
            child5.transform.localPosition = childLoc5;
            child6.transform.localPosition = childLoc6;
            //Stops the jetpack
            JetPack j = FindObjectOfType<JetPack>();
            j.EndJetPackEarly();
        }
        
    }

    /*
    public void Handle_TimeSlowEvent()
    {
        //Adjusts force relative to time
        float tempSpeed = (float)(defaultSpeed * .02);
        //speedForceApplied = tempSpeed / Time.fixedDeltaTime;

        
    }
    public void OnDestroy()
    {
        TimeSlow.slowTimeEvent -= Handle_TimeSlowEvent;
    }*/

    public void allowPush()
    {
        canPushed = true;
    }

    //Ignore this
    //call from another Class
    //gameObjectVariableName.GetComponent<Codename>.functionCalled
}
