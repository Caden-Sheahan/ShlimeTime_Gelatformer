using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour
{
    public GameObject Player;

    private Vector2 ReturnToHub = new Vector2(269, 9.5f);
    private Vector2 CaveWarp = new Vector2(-30, 7);
    private Vector2 JungleWarp = new Vector2(332, -2);
    private Vector2 CastleWarp = new Vector2(222, 158);

    // Update is called once per frame
    void Update()
    {
        //warp to Hub
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player.transform.position = ReturnToHub;
        }
        //warp to Cave
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.transform.position = CaveWarp;
        }
        //warp to Jungle
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.transform.position = JungleWarp;
        }
        //warp to Castle
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.transform.position = CastleWarp;
        }
    }
}
