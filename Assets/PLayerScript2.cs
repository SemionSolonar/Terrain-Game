using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerScript2 : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
        }

    }
}
