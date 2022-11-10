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

    void Start()
    {
        tutorialImage.enabled = false;
        isInfoActive = true;
        isAccessActive = true;
        GameController.isTimeOn = true;
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
        else
        {
            timeToggleButton.SetActive(true);
            isAccessActive = false;
        }
    }

    public void TimeToggle(bool toggleTime)
    {
        GameController.isTimeOn = toggleTime;
    }
}
