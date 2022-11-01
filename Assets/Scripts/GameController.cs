using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    private Vector2 ReturnToHub = new Vector2(269, 9.5f);

    //public GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Player.transform.position = ReturnToHub;
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    PauseUI.SetActive(true);
        //    Time.timeScale = 0;
        //}
    }
}
