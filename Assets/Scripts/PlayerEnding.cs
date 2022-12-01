using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour
{
    Animator playerAnim;
    Animator crownAnim;

    private void Start()
    {
        playerAnim = GameObject.Find("SlimeBoi").GetComponent<Animator>();
        crownAnim = GameObject.Find("SlimeCrown").GetComponent<Animator>();
    }

    public void Roll()
    {
        playerAnim.enabled = true;
        crownAnim.SetTrigger("FallOff");
    }
}
