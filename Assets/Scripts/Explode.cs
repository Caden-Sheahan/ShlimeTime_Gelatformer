using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("remove", destroyTime);
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
