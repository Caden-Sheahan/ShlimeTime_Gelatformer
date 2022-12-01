using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;
    public Vector2 endPos = new Vector2();
    Rigidbody2D rb2d;
    Animator playerAnim;
    Animator crownAnim;
    Animator timeAnim;

    private void Start()
    {
        crownAnim = GameObject.Find("SlimeCrown").GetComponent<Animator>();
        timeAnim = GameObject.Find("TimeSlowUI").GetComponent<Animator>();
        rb2d = Player.GetComponentInChildren<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisableControls();
    }

    private void DisableControls()
    {   
        // warp onto throne
        Player.transform.position = endPos;
        // stop moving
        rb2d.velocity = Vector2.zero;
        // Stop Time if on (Ryan help here pls)
        TimeSlow s = FindObjectOfType<TimeSlow>();   
        s.speedBackUp();
        s.enabled = false;
        timeAnim.SetBool("SlowDownTime", false);
        timeAnim.SetBool("SpeedUpTime", false);
        // Push off
        MainCamera.GetComponent<Shoot>().enabled = false;
        // Jetpack off
        Player.GetComponent<JetPack>().enabled = false;
        // Swing off
        Player.GetComponent<Swing>().enabled = false;
        Player.GetComponent<LineRenderer>().enabled = false;
        Player.GetComponent<DistanceJoint2D>().enabled = false;
        // Set eyes to look forward
        GameObject.Find("Player Eyes").transform.rotation = Quaternion.Euler(0, 0, 0);

        // Begin end animation sequence
        crownAnim.SetTrigger("Fall");
    }
}