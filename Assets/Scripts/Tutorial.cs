using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public string[] TextTriggers = 
        new string[]{"Intro1", "Intro2", "Intro3"};
    public GameObject[] TutorialTexts = new GameObject[4];

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == TextTriggers[0])
        {
            TutorialTexts[0].SetActive(true);
        }
        else if (col.gameObject.name == TextTriggers[1])
        {
            TutorialTexts[0].SetActive(false);
        }
        else if (col.gameObject.name == TextTriggers[2])
        {
            TutorialTexts[1].SetActive(false);
        }
        else if (col.gameObject.name == TextTriggers[3])
        {
            TutorialTexts[2].SetActive(false);
        }
        else if (col.gameObject.name == TextTriggers[4])
        {
            TutorialTexts[3].SetActive(false);
        }
        else if (col.gameObject.name == TextTriggers[5])
        {
            TutorialTexts[4].SetActive(false);
        }
    }
}
