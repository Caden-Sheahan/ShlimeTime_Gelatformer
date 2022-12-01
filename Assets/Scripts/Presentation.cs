using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour
{
    public GameObject Player;

    public Vector2[] warp = new Vector2[4];
    //public Vector2 ReturnToHub = new Vector2(269, 9.5f);
    //public Vector2 CaveWarp = new Vector2(-30, 7);
    //public Vector2 JungleWarp = new Vector2(332, -2);
    //public Vector2 CastleWarp = new Vector2(163, 123);

    // Update is called once per frame
    void Update()
    {
        //warp to Hub
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player.transform.position = warp[0];
        }
        //warp to Cave
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.transform.position = warp[1];
        }
        //warp to Jungle
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.transform.position = warp[2];
        }
        //warp to Castle
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.transform.position = warp[3];
        }
    }
}
