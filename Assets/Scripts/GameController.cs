using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    private Vector2 ReturnToHub = new Vector2(269, 9.5f);

    //public GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player.transform.position = ReturnToHub;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit!");
            Application.Quit();
        }
    }
}
