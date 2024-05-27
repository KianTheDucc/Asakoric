using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    public float mouseSensitivity = 1000f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        CursorLook();
    }

    private void CursorLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        //Clamp the X rotation so we don't become an Owl
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //control the rotation around the Y axis

        yRotation += mouseX;


        //Apply the rotation
        transform.localRotation = Quaternion.Euler(-xRotation, yRotation, 0f);
    }
}
