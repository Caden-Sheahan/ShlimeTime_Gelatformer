using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class JetPack : MonoBehaviour
{
    Rigidbody2D rb;
    float speedForceApplied = 3;
    float defaultSpeed;
    bool floating = false;
    public static bool canFloat = true;
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    public GameObject child4;
    public GameObject child5;
    public GameObject child6;

    public GameObject slimeBod;
    public GameObject slimeEyes;

    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speedForceApplied;
        rb = GetComponent<Rigidbody2D>();
        //TimeSlow.jetpackSlowTimeEvent += Handle_TimeSlowEvent;

        slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.red;
        slimeEyes.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && canFloat && !Swing.dontResetJetPackAgain)
        {
            FindObjectOfType<AudioManager>().Play("Push1");
            floating = true;
            Invoke("JetpackJump", 1.3f);
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .65f);

            slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.red;
            slimeEyes.GetComponent<SpriteRenderer>().color = Color.red;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Finds the direction the player needs to move
        //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //var mouseDir = mousePos - gameObject.transform.position;


        if (floating == true)
        {
            canFloat = false;
            ChildGravNone();
            rb.AddForce(Vector3.up * speedForceApplied);
            rb.velocity = new Vector2(rb.velocity.x * .95f, rb.velocity.y);
            if(rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y *.85f);
            }
        }
        else
        {
            //returns child gravity to correct values
            ChildGravReset();
        }
    }

    void JetpackJump()
    {
        // Finds the direction the player needs to move
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        floating = false;
        Invoke("CanJetPack", 1.5f);
        mouseDir.z = 0;
        mouseDir.Normalize();

        rb.AddForce(mouseDir * speedForceApplied, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("SwingRelease");
    }

    /*
    public void Handle_TimeSlowEvent()
    {
        //Adjusts force applied relative to speed
        float tempSpeed = (float)(defaultSpeed * .02);
        //speedForceApplied = tempSpeed / Time.fixedDeltaTime;
    }*/
    

    public void EndJetPackEarly()
    {
        CanJetPack();

        ChildGravReset();

        floating = false;
        CancelInvoke("JetpackJump");

    }
    public void CanJetPack()
    {
        canFloat = true;
        //Swing.dontResetJetPackAgain = false;
    }

    void ChildGravNone()
    {
        //makes player gravity 0 while using jetpack
        rb.gravityScale = 0;
        child1.GetComponent<Rigidbody2D>().gravityScale = 0;
        child2.GetComponent<Rigidbody2D>().gravityScale = 0;
        child3.GetComponent<Rigidbody2D>().gravityScale = 0;
        child4.GetComponent<Rigidbody2D>().gravityScale = 0;
        child5.GetComponent<Rigidbody2D>().gravityScale = 0;
        child6.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void ChildGravReset()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        //resets player gravity
        rb.gravityScale = 1;
        //resets child gravity
        child1.GetComponent<Rigidbody2D>().gravityScale = 1;
        child2.GetComponent<Rigidbody2D>().gravityScale = 1;
        child3.GetComponent<Rigidbody2D>().gravityScale = 1;
        child4.GetComponent<Rigidbody2D>().gravityScale = 1;
        child5.GetComponent<Rigidbody2D>().gravityScale = 1;
        child6.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void CoolDownCancel()
    {
        CancelInvoke("JetPackJump");
        CancelInvoke("CanJetPack");
    }

    public void CoolDownRestart()
    {
        CancelInvoke("JetPackJump");
        Invoke("CanJetPack", 1.5f);
    }

}
