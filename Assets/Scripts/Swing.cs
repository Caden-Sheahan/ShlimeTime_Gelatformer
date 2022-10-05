using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //READ ME - Made using a tutorial from https://www.youtube.com/watch?v=P-UscoFwaE4

    public Camera mainCamera;
    public LineRenderer lineRender;
    public DistanceJoint2D distJoint;
    public Rigidbody2D rb;
    bool allowGrapple = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRender = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();
        distJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.D) && allowGrapple)
        {
            //Shoots the grapple
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRender.SetPosition(0, mousePos);
            lineRender.SetPosition(1, transform.position);
            distJoint.connectedAnchor = mousePos;
            distJoint.enabled = true;
            lineRender.enabled = true;

            
        }
        else if (Input.GetKeyUp(KeyCode.D) && allowGrapple)
        {
            Recall();
            
        }
        if (distJoint.enabled)
        {
            lineRender.SetPosition(1, transform.position);
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
