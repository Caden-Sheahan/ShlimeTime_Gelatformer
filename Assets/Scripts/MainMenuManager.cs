using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image tutorialImage;
    public GameObject timeToggleButton;
    public bool isInfoActive;
    public bool isAccessActive;
    public static bool isTimeToggled;

    void Start()
    {
        tutorialImage.enabled = false;
        isInfoActive = true;
        isAccessActive = true;
        isAccessActive = true;
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

    public void AccessAccessibility()
    {
        if (!isAccessActive)
        {
            timeToggleButton.SetActive(false);
            isAccessActive = true;
        }
        else if (isAccessActive)
        {
            timeToggleButton.SetActive(true);
            isAccessActive = false;
        }
    }

    public void ToggleTime()
    {
        if (!isTimeToggled)
        {
            isTimeToggled = true;
        }
        else if (isTimeToggled)
        {
            isTimeToggled = false;
        }
    }
}
