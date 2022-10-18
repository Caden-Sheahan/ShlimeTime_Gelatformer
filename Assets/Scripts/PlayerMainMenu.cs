using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
{
    int playerMove = 0;
    int randNumX = 0;
    int randNumY = 0;

    // Start is called before the first frame update
    void Start()
    {
        randNumY = Random.Range(0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove++;

        if (playerMove == 0 || playerMove == 250 || playerMove == 500 || playerMove == 750)
        {
            randNumX = Random.Range(0, 2);
        }
        if (playerMove == 125 || playerMove == 375 || playerMove == 625 || playerMove == 875)
        {
            randNumY = Random.Range(0, 2);
        }

        if (randNumX == 0 && transform.position.x < 5)
        {
            transform.position = new Vector2(transform.position.x + .002f, transform.position.y);
        }
        if (randNumX == 1 &&  transform.position.x > 2)
        {
            transform.position = new Vector2(transform.position.x - .002f, transform.position.y);
        }
        if (randNumY == 0 && transform.position.y < 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + .002f);
        }
        if (randNumY == 1 && transform.position.y > -2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - .002f);
        }
        /*
        if (playerMove > 0 && playerMove < 250)
        {
            transform.position = new Vector2(transform.position.x + .002f, transform.position.y);
        }
        if (playerMove > 25 && playerMove < 225)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - .002f);
        }
        if (playerMove > 250 && playerMove < 500)
        {
            transform.position = new Vector2(transform.position.x - .002f, transform.position.y);
        }
        if (playerMove > 275 && playerMove < 475)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.002f);
        }
        if (playerMove > 500 && playerMove < 750)
        {
            transform.position = new Vector2(transform.position.x - .002f, transform.position.y);
        }
        if (playerMove > 525 && playerMove < 725)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.002f);
        }
        if (playerMove > 750 && playerMove < 1000)
        {
            transform.position = new Vector2(transform.position.x - .002f, transform.position.y);
        }
        if (playerMove > 775 && playerMove < 975)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.002f);
        }*/

        if (playerMove > 1000)
        {
            playerMove = 0;
        }
        Debug.Log(playerMove);
    }
}
