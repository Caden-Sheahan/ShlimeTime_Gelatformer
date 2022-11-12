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
        mainCam.GetComponent<Shoot>().enabled = false;
        gameObject.GetComponent<TimeSlow>().enabled = false;
        gameObject.GetComponent<JetPack>().enabled = false;
        gameObject.GetComponent<Swing>().enabled = false;

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;

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
        if (collision.gameObject.tag == "PU1")
        {
            mainCam.GetComponent<Shoot>().enabled = true;
            controlsText[0].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");

            JsonManager.instance.SavePush(true);
        }
        if (collision.gameObject.tag == "PU2")
        {
            gameObject.GetComponent<TimeSlow>().enabled = true;
            controlsText[1].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");

            JsonManager.instance.SaveTime(true);
        }
        if (collision.gameObject.tag == "PU3")
        {
            gameObject.GetComponent<JetPack>().enabled = true;
            controlsText[2].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");

            JsonManager.instance.SaveJetPack(true);
        }
        if (collision.gameObject.tag == "PU4")
        {
            gameObject.GetComponent<Swing>().enabled = true;
            controlsText[3].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PowerGain");

            JsonManager.instance.SaveSwing(true);
        }
    }
}
