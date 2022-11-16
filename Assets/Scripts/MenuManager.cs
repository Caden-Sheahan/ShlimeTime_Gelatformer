using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject HowToPlayMenu;
    public GameObject TimeMenu;
    public GameObject ControlMenu;
    public GameObject CreditsMenu;
    public bool isInfoActive;
    public bool creditsActive;

    void Start()
    {
        isInfoActive = true;
        creditsActive = true;
        GameController.isTimeOn = true;
    }

    // ADD JSON ON THIS ONE
    public void NewSave()
    {
        JsonManager.instance.SavePos(new Vector2(-13, 110));
        JsonManager.instance.SavePush(false);
        JsonManager.instance.SaveTime(false);
        JsonManager.instance.SaveJetPack(false);
        JsonManager.instance.SaveSwing(false);
        JsonManager.instance.SavePlatform(false);
        SceneManager.LoadScene("Map");
    }

    public void ContinueSave()
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
        if(!isInfoActive) 
        {
            HowToPlayMenu.SetActive(false);
            isInfoActive = true;
        }
        else
        {
            HowToPlayMenu.SetActive(true);
            isInfoActive = false;
        }
    }

    public void ViewCredits()
    {
        if (!creditsActive)
        {
            CreditsMenu.SetActive(false);
            creditsActive = true;
        }
        else
        {
            CreditsMenu.SetActive(true);
            creditsActive = false;
        }
    }    

    public void NextPage()
    {
        ControlMenu.SetActive(false);
        TimeMenu.SetActive(true);
    }

    public void PreviousPage()
    {
        ControlMenu.SetActive(true);
        TimeMenu.SetActive(false);
    }

    public void TimeToggle(bool toggleTime)
    {
        GameController.isTimeOn = toggleTime;
    }
}
