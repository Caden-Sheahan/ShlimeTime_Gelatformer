using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAction : MonoBehaviour
{
    public GameObject explosion;
    //Vector3 move = (transform.position.x, transform.position.y);

    // Start is called before the first frame update
    void Start()
    {
        Invoke("remove", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = (transform.position.x, transform.position.y, transform.position.z);
    }

    void remove()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}