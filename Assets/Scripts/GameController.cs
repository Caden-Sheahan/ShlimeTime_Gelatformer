using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject timeBrazier;
    public static bool isTimeOn;
    //private Vector2 ReturnToHub = new Vector2(269, 9.5f);
    //public GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit!");
            Application.Quit();
        }

        if (isTimeOn)
        {
            timeBrazier.SetActive(true);
        }
        else
        {
            timeBrazier.SetActive(false);
        }
    }

    //warp to hub code:
    //if (Input.GetKeyDown(KeyCode.Tab))
    //{
    //    Player.transform.position = ReturnToHub;
    //}
}
