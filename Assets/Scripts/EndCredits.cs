using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public void EndOfCredits()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }
}
