using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TorchBehaviour : MonoBehaviour
{
    public void LightTorch()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Lit");
    }
}
