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

    // ADD JSON ON THIS ONE
    public void NewGame()
    {
        JsonManager.instance.SavePos(new Vector2(-31,9.1f));
        JsonManager.instance.SavePush(false);
        JsonManager.instance.SaveTime(false);
        JsonManager.instance.SaveJetPack(false);
        JsonManager.instance.SaveSwing(false);
        SceneManager.LoadScene("Map");
    }

    public void ContinueGame()
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
            timeToggleButton.SetActive(false);
            isInfoActive = true;
        }

        else if (isInfoActive == true)
        {
            tutorialImage.enabled = true;
            timeToggleButton.SetActive(true);
            isInfoActive = false;
        }
    }

    //public void AccessAccessibility()
    //{
    //    if (!isAccessActive)
    //    {
    //        timeToggleButton.SetActive(false);
    //        isAccessActive = true;
    //    }
    //    else
    //    {
    //        timeToggleButton.SetActive(true);
    //        isAccessActive = false;
    //    }
    //}

    public void TimeToggle(bool toggleTime)
    {
        GameController.isTimeOn = toggleTime;
    }
}
