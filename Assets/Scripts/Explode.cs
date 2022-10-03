using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("remove", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void remove()
    {
        //Destroys the explosion after a short time
        Destroy(this.gameObject);
    }
    
}
