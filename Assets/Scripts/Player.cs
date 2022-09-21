using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x * Mathf.Rad2Deg);
        //transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        
            //GameObject rocketCurrent = Instantiate(rocket, transform.position, Quaternion.identity);
            /*
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rocketCurrent.transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rocketCurrent.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + 0);
            */

            /*
            Rigidbody rigidRocket = rocket.GetComponent<Rigidbody>();
            rigidRocket.AddRelativeForce(transform.forward * 5 * Time.deltaTime);
            rigidRocket.MovePosition(new Vector3(0,5,0));
            */
            


            /*
            Vector3 mousePos = Input.mousePosition;
            GameObject rocketCurrent = Instantiate(rocket, transform.position, Quaternion.identity);
            float angle = Mathf.Atan2(mousePos.y - rocketCurrent.transform.position.y, mousePos.x - rocketCurrent.transform.position.x) * (180 / Mathf.PI);
            rocketCurrent.transform.Rotate(0, 0, angle);
            //rocketCurrent.transform.LookAt(mousePos);
            //rocketCurrent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mousePos.z));

            Rigidbody rigidRocket = rocket.GetComponent<Rigidbody>();
            //rigidRocket.AddRelativeForce(transform.forward * 5 * Time.deltaTime);
            rigidRocket.MovePosition(mousePos);
            */

        
        //bool lClick = Input.GetMouseButtonDown(0);
        //print(lClick);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explode")
        {
            var force = transform.position - collision.transform.position;
            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * 500);
        }
    }

    //call from another Class
    //gameObjectVariableName.GetComponent<Codename>.functionCalled
}
