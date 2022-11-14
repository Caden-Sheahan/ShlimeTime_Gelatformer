using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject timeBrazier;
    public static bool isTimeOn;
    public GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }  
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
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
    /// <summary>
    /// Time.timeScale = 1;
    /// Time.fixedDeltaTime = 0.02f;
    /// </summary>
    public void PauseGame()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    //warp to hub code:
    //private Vector2 ReturnToHub = new Vector2(269, 9.5f);
    //if (Input.GetKeyDown(KeyCode.Tab))
    //{
    //    Player.transform.position = ReturnToHub;
    //}
}
