using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatformEnabler : MonoBehaviour
{
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Creates that platform over the crystal cave to prevent falling back in
        if(collision.gameObject.tag == "Player")
        {
            drop.SetActive(true);
        }
    }
}
