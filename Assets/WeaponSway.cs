using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{

    public float swayAmount = 0.02f;         // Amount of weapon sway
    public float maxSwayAmount = 0.06f;      // Maximum amount of weapon sway
    public float swaySmoothness = 4f;        // Smoothness of weapon sway

    [SerializeField] private ParticleSystem ps;

    private Vector3 initialPosition;         // Initial position of the weapon
    private Vector3 targetPosition;          // Target position for weapon sway

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate weapon sway in both X and Y axes
        float moveX = -Input.GetAxis("Mouse X") * swayAmount;
        float moveY = -Input.GetAxis("Mouse Y") * swayAmount;

        // Clamp weapon sway within the maximum sway amount
        moveX = Mathf.Clamp(moveX, -maxSwayAmount, maxSwayAmount);
        moveY = Mathf.Clamp(moveY, -maxSwayAmount, maxSwayAmount);

        // Calculate the target position for weapon sway
        targetPosition = new Vector3(moveX, moveY, 0f);

        // Smoothly interpolate towards the target position
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition + initialPosition, Time.deltaTime * swaySmoothness);

        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        else
        {
            return;
        }
    }

    void Fire()
    {
        // Play the fire animation
        ps.Play();
    }
}
