using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator crownAnim;
    Animator timeAnim;
    public GameObject MainCamera;
    public GameObject Player;
    #region children
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    public GameObject child4;
    public GameObject child5;
    public GameObject child6;
    Vector2 childLoc1;
    Vector2 childLoc2;
    Vector2 childLoc3;
    Vector2 childLoc4;
    Vector2 childLoc5;
    Vector2 childLoc6;
    #endregion
    public Vector2 endPos = new Vector2();
    public static bool GameEnding = false;

    private void Start()
    {
        crownAnim = GameObject.Find("SlimeCrown").GetComponent<Animator>();
        timeAnim = GameObject.Find("TimeSlowUI").GetComponent<Animator>();
        rb2d = Player.GetComponentInChildren<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisableControls();
        GameEnding = true;
    }

    private void DisableControls()
    {   
        // warp onto throne
        Player.transform.position = endPos;
        // stop moving
        rb2d.velocity = Vector2.zero;
        child1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        child2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        child3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        child4.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        child5.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        child6.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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