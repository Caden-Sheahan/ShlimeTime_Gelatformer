using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour
{
    public GameObject Player;

    private Vector2 CaveWarp = new Vector2(-30, 7);
    private Vector2 JungleWarp = new Vector2(332, -2);
    private Vector2 CastleWarp = new Vector2(215, 54);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.transform.position = CaveWarp;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.transform.position = JungleWarp;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.transform.position = CastleWarp;
        }
    }
}
