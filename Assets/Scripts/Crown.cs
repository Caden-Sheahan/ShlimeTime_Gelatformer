using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject EndGamePanel;
    Animator playerAnim;
    Animator crownAnim;

    private void Start()
    {
        playerAnim = GameObject.Find("Player Eyes").GetComponent<Animator>();
        crownAnim = GameObject.Find("SlimeCrown").GetComponent<Animator>();
    }

    public void Shine()
    {
        crownAnim.SetTrigger("Shine");
    }

    public void Blink()
    {
        playerAnim.SetTrigger("Blink");
    }

    public void FadeOut()
    {
        EndGamePanel.GetComponent<Animator>().SetTrigger("Fade");
    }
}
