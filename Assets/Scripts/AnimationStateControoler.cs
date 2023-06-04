using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AnimationStateControoler : MonoBehaviour
{
     Animator animator;
    float velacity = 0.0f;
    public float acc = 0.1f;
    public float des = 0.5f;
    int velocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        velocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed)
        {
            velacity += Time.deltaTime * acc;
        }

        if (!forwardPressed)
        {
            velacity -= Time.deltaTime * des;
        }

        animator.SetFloat(velocityHash, velacity);
    }
}
