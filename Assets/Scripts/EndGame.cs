using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;
    Animator playerAnim;
    Animator crownAnim;

    private void Start()
    {
        crownAnim = GameObject.Find("SlimeCrown").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisableControls();
    }

    private void DisableControls()
    {
        MainCamera.GetComponent<Shoot>().enabled = false;
        Player.GetComponent<JetPack>().enabled = false;
        Player.GetComponent<TimeSlow>().enabled = false;
        Player.GetComponent<Swing>().enabled = false;
        Player.GetComponent<LineRenderer>().enabled = false;
        GameObject.Find("Player Eyes").transform.rotation = Quaternion.Euler(0, 0, 0);

        crownAnim.SetTrigger("Fall");
    }
}