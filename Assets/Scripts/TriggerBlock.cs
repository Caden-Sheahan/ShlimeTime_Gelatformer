using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndGameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "EndGame")
        {
            EndGameUI.SetActive(true);
            //Time.timeScale = 0;
        }
    }
}
