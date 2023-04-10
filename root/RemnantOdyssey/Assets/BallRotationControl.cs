using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotationControl : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject playerSphere;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component of the game object that this script is attached to
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game object has a non-zero velocity
        if (controller.velocity != Vector3.zero)
        {
            // Get the direction of the game object's velocity
            Vector3 direction = controller.velocity.normalized;

            // Get the speed of the game object's velocity
            float speed = controller.velocity.magnitude;

            // Calculate the axis of rotation based on the direction of movement and the radius of the ball
            Vector3 axis = Vector3.Cross(Vector3.up, -direction);

            // Rotate the ball around the axis of rotation based on the speed of movement
            playerSphere.transform.Rotate(axis, speed / 0.5f * Time.deltaTime);
            Debug.Log(speed);
            Debug.Log(direction);
        }
    }
}
