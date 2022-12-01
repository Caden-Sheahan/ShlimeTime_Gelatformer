using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour
{
    public GameObject Player;
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
        playerAnim.SetTrigger("Roll");
        crownAnim.SetTrigger("FallOff");
    }
}