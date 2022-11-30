using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;

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
    }
}