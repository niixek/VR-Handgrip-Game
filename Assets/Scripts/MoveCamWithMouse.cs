using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamWithMouse : MonoBehaviour
{
    public Camera cameraToMove;
    public float sensitivity;
    float mouseX;
    float mouseY;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX * sensitivity, 0);
        cameraToMove.transform.Rotate(-mouseY * sensitivity, 0, 0);
    }
}
