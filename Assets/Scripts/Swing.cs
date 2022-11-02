using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Swing : MonoBehaviour
{
    //READ ME - Made using a tutorial from https://www.youtube.com/watch?v=P-UscoFwaE4

    public Camera mainCamera;
    public LineRenderer lineRender;
    public DistanceJoint2D distJoint;
    public Rigidbody2D rb;
    bool allowGrapple = true;
    public GameObject slimeBod;
    public GameObject slimeEyes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRender = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();
        distJoint.enabled = false;

        slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.blue;
        slimeEyes.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && allowGrapple)
        {
            //Shoots the grapple
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRender.SetPosition(0, mousePos);
            lineRender.SetPosition(1, transform.position);
            distJoint.connectedAnchor = mousePos;
            distJoint.enabled = true;
            lineRender.enabled = true;
            rb.velocity = new Vector2(rb.velocity.x * 1.25f, rb.velocity.y);

            slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.blue;
            slimeEyes.GetComponent<SpriteRenderer>().color = Color.blue;

        }
        else if (Input.GetKeyUp(KeyCode.W) && allowGrapple)
        {
            Recall();
            
        }
        if (distJoint.enabled)
        {
            lineRender.SetPosition(1, transform.position);
        }
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && allowGrapple)
        {
            rb.velocity = new Vector2(rb.velocity.x * 1.001f, rb.velocity.y);
        }
    }

    void canGrapple()
    {
        //Checks if the player can grapple
        allowGrapple = true;
    }

    public void Recall()
    {
        //Recalls the grapple
        distJoint.enabled = false;
        lineRender.enabled = false;

        allowGrapple = false;
        Invoke("canGrapple", .4f);

        if ((rb.velocity.x < 11 && rb.velocity.y < 11) && (rb.velocity.x > -11 && rb.velocity.y > -11))
        {
            rb.velocity = new Vector2(rb.velocity.x * 1.25f, rb.velocity.y * 1.5f);

        }
    }
}
