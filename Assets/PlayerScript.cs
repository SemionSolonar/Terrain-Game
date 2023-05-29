using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 3d Character Controller
    public CharacterController controller;

    // Player Movement Speed
    public float speed = 12f;

    // Gravity
    public float gravity = -9.81f;

    // Ground Check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Jump Height
    public float jumpHeight = 3f;

    // Velocity
    Vector3 velocity;

    // Grounded
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Get Character Controller
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
