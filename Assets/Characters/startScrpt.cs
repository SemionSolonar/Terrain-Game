using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScrpt : MonoBehaviour
{

    public Animator anim;
    public Transform cameraTransform; // Reference to the camera's transform component
    public Transform weaponTransform; // Reference to the weapon's transform component

    public float rotationSpeed = 5f; // Speed of camera rotation


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Aim();
            // Get the mouse movement on the Y-axis
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotate the camera on the X-axis
            float rotationAmount = -mouseY * rotationSpeed;
            cameraTransform.Rotate(rotationAmount, 0f, 0f);

            // Get the current camera rotation
            Vector3 cameraRotation = cameraTransform.rotation.eulerAngles;

            cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90f, 90f);

            // Apply the new camera rotation
            cameraTransform.rotation = Quaternion.Euler(cameraRotation);

            // Rotate the weapon to match the camera rotation
            weaponTransform.rotation = cameraTransform.rotation;
        }
        else
        {

            AimDown();
        }
    }

    void Aim()
    {
        anim.SetBool("Aim", true);
    }

    void AimDown()
    {
        anim.SetBool("Aim", false);
    }


}
