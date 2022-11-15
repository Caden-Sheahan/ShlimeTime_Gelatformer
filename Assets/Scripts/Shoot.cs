using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Shoot : MonoBehaviour
{
    private Vector3 target;
    public GameObject player;
    public GameObject rocketPrefab;
    public GameObject slimeBod;
    public GameObject slimeEyes;

    public float bulletSpeed = 15f;
    bool shootCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.green;
        slimeEyes.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        //Find mouse Position
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //Finds difference in distance from mouse to player
        Vector3 difference = target - player.transform.position;
        //Creates a rotation that is facing towards the mouse
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Rotates Z rotation of the player towards the mouse
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90);
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            //Turns the difference into a specific length value
            float distance = difference.magnitude;
            //Creates a value equivalent to a line from the player and the mouse
            Vector2 direction = difference / distance;
            direction.Normalize();
            //Activates the fire rocket code while providing direction and rotation
            fireRocket(direction, rotationZ);

            //slimeBod.GetComponent<SpriteShapeRenderer>().color = new Color(138,255,69,255);
            slimeBod.GetComponent<SpriteShapeRenderer>().color = Color.green;
            slimeEyes.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void fireRocket(Vector2 direction, float rotationZ)
    {
        if(shootCooldown == false)
        {
            shootCooldown = true;
            Invoke("canShoot", .3f);
            //Creates a rocket
            GameObject r = Instantiate(rocketPrefab) as GameObject;
            //Sets rocket position to player position
            r.transform.position = player.transform.position;
            //Rotates the rocket towards the mouse
            r.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
            //Plays shoot sound
            FindObjectOfType<AudioManager>().Play("BombShoot");
            //Sends the rocket flying
            r.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
        
    }

    void canShoot()
    {
        shootCooldown = false;
    }
}
