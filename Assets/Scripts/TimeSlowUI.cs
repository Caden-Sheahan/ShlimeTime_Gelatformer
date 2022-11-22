using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowUI : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void UnfreezeTime()
    {
        anim.SetBool("SlowDownTime", false);
    }

}
