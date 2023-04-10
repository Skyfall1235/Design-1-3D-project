//////////////////////////////////////////////////////
// Assignment/Lab/Project: FinalGame
//Name: Wyatt Murray
//Section: 2022FA.SGD.113.2173
//Instructor: Brian Sowers
// Date: 11/30/22
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Orbit3rdPersonCameraController : MonoBehaviour
{
    public float yMin = -20;
    public float yMax = 40;
    float xRotation = 0;
    float yRotation = 0;
    public Transform target;
    public float distance = 10.0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //this one hurt my brain a lot


        //set a vector2 to get the mouse inputs
        Vector2 controlInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //keep the X rotation within range of a 360 degree rotation
        xRotation += Mathf.Repeat(controlInput.x, 360.0f);
        //takes the mouse y input and adds or subtracts to yRot
        yRotation -= controlInput.y;

        //clamp those mf so you cant get an upside down camera
        yRotation = Mathf.Clamp(yRotation, yMin, yMax);

        //set those rotations we just did math for, into the quaternions, and then set them so they can move up or down, and left or right
        Quaternion newRotation = Quaternion.AngleAxis(xRotation, Vector3.up);
        newRotation *= Quaternion.AngleAxis(yRotation, Vector3.right);

        //finally, set your transform and rotations to be thier new locations, with the proper distance between the target and the player
        transform.rotation = newRotation;
        transform.position = target.position - (transform.forward * distance);
    }
}

