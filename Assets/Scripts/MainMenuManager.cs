using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image tutorialImage;
    public bool isInfoActive;

    void Start()
    {
        tutorialImage.enabled = false;
        isInfoActive = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Debug.Log("Game Hath Quit");
        Application.Quit();
    }

    public void HowToGame()
    {
        if(isInfoActive == false) 
        {
            tutorialImage.enabled = false;
            isInfoActive = true;
        }

        else if (isInfoActive == true)
        {
            tutorialImage.enabled = true;
            isInfoActive = false;
        }
    }
}
