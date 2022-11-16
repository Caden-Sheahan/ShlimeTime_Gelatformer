using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject Player;
    public GameObject timeBrazier;
    public GameObject Buttons;
    public GameObject HowToPlayMenu;
    public static bool isTimeOn;
    public GameObject PauseUI;
    float tempTime;
    private Vector2 ReturnToHub = new Vector2(269, 9.5f);

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
        //warp to hub code:
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player.transform.position = ReturnToHub;
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

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            tempTime = Time.timeScale;

            PauseUI.SetActive(true);
        
            Time.timeScale = 0;

            mainCam.GetComponent<Shoot>().enabled = false;
            Player.GetComponent<TimeSlow>().enabled = false;
            Player.GetComponent<JetPack>().enabled = false;
            Player.GetComponent<Swing>().enabled = false;
        }
    }

    public void ResumeGame()
    {
        PauseUI.SetActive(false);
        Time.timeScale = tempTime;

        mainCam.GetComponent<Shoot>().enabled = JsonManager.instance.GSD.hasPush;
        Player.GetComponent<TimeSlow>().enabled = JsonManager.instance.GSD.hasSlow;
        Player.GetComponent<JetPack>().enabled = JsonManager.instance.GSD.hasJetPack;
        Player.GetComponent<Swing>().enabled = JsonManager.instance.GSD.hasSwing;
    }

    public void HowToGame()
    {
        HowToPlayMenu.SetActive(true);
        Buttons.SetActive(false);
    }

    public void BackButton()
    {
        HowToPlayMenu.SetActive(false);
        Buttons.SetActive(true);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quiiiiiiit");
    }
}
