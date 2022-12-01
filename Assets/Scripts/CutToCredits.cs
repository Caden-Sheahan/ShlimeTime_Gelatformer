using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutToCredits : MonoBehaviour
{
    public void FadeToCredits()
    {
        SceneManager.LoadScene(2);
    }
}
