using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    Animator playerAnim;
    Animator crownAnim;

    private void Start()
    {
        playerAnim = GameObject.Find("PlayerEyes").GetComponent<Animator>();
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
}
