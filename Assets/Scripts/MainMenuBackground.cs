using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    public float movespeed = 1;
    public float resetY = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + movespeed);

        if (transform.position.y >= resetY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - resetY*2);
        }
    }

}
