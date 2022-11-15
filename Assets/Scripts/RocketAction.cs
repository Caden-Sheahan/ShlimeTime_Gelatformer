using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAction : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("remove", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void remove()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if enemy collides with walls
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("BombExplode");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}