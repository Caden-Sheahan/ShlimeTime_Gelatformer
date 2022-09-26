using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D door)
    {
        if (door.CompareTag("Player"))
        {
            virtualCam.SetActive(true);
        }
    } 
    private void OnTriggerExit2D(Collider2D door)
    {
        if (door.CompareTag("Player"))
        {
            virtualCam.SetActive(false);
        }
    }
}
