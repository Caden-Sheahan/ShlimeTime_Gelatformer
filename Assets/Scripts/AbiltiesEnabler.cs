using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbiltiesEnabler : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject[] controlsText = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        //Disables all abilities by dafault
        mainCam.GetComponent<Shoot>().enabled = false;
        gameObject.GetComponent<TimeSlow>().enabled = false;
        gameObject.GetComponent<JetPack>().enabled = false;
        gameObject.GetComponent<Swing>().enabled = false;

        //Makes certain time is correct
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;

        //Sets abilities active states based on Json
        mainCam.GetComponent<Shoot>().enabled =  JsonManager.instance.GSD.hasPush;
        gameObject.GetComponent<TimeSlow>().enabled = JsonManager.instance.GSD.hasSlow;
        gameObject.GetComponent<JetPack>().enabled = JsonManager.instance.GSD.hasJetPack;
        gameObject.GetComponent<Swing>().enabled = JsonManager.instance.GSD.hasSwing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gains power up 1
        if (collision.gameObject.tag == "PU1")
        {
            //Enables push script
            mainCam.GetComponent<Shoot>().enabled = true;
            controlsText[0].SetActive(true);
            //Plays sfx
            FindObjectOfType<AudioManager>().Play("PowerGain");
            //Saves ownership of push in Json
            JsonManager.instance.SavePush(true);
        }
        if (collision.gameObject.tag == "PU2")
        {
            //enables time slow script
            gameObject.GetComponent<TimeSlow>().enabled = true;
            controlsText[1].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");
            //Saves ownership of time slow in Json
            JsonManager.instance.SaveTime(true);
        }
        if (collision.gameObject.tag == "PU3")
        {
            //enables jetpack script
            gameObject.GetComponent<JetPack>().enabled = true;
            controlsText[2].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");
            //saves ownership of jetpack in Json
            JsonManager.instance.SaveJetPack(true);
        }
        if (collision.gameObject.tag == "PU4")
        {
            //enables swing script
            gameObject.GetComponent<Swing>().enabled = true;
            controlsText[3].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");
            //saves ownership of swing in Json
            JsonManager.instance.SaveSwing(true);
        }
    }
}
