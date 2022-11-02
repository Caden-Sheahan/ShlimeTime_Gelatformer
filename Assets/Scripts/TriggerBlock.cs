using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    public GameObject Player;
    public GameObject EndGameUI;

    private Vector2 CaveWarp = new Vector2(-30, 7);
    private Vector2 JungleWarp = new Vector2(383, -2);
    private Vector2 CastleWarp = new Vector2(215, 54);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "EndGame")
        {
            EndGameUI.SetActive(true);
            //Time.timeScale = 0;
        }
        else if (gameObject.name == "CaveWarp")
        {
            Player.transform.position = CaveWarp;
        }
        else if (gameObject.name == "JungleWarp")
        {
            Player.transform.position = JungleWarp;
        }
        else if (gameObject.name == "CastleWarp")
        {
            Player.transform.position = CastleWarp;
        }
    }
}
