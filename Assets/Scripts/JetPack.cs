using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = 0;
            rb.AddForce(mouseDir * 75 * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.gravityScale = 1;
        }
    }
}
