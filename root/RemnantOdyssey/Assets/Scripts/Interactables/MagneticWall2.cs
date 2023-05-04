using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MagneticWall2 : MonoBehaviour
{
    //link to the player data to see if the player has turned it off
    [Header("Force Data")]
    //force to push against the player
    [SerializeField] private float appliedForce;
    [SerializeField] private float displayTimerAmount;
    private bool playerIsColliding;
    private Vector3 pushbackDirection;
    public bool PowerStateOn = true;

    [Header("World Space UI")]
    [SerializeField] GameObject displayCanvas;
    [SerializeField] GameObject warningPanel;
    [SerializeField] GameObject welcomePanel;

    private void Update()
    {

    }
    private void Start()
    {
        pushbackDirection = transform.forward;
    }

    private IEnumerator Pushback(GameObject player)
    {
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        Vector3 force = pushbackDirection * appliedForce;
        while (playerIsColliding && PowerStateOn)
        {
            playerRB.AddForce(force);
            yield return null;
        }
    }
    private IEnumerator DisplayDoorPanelWarning(float timeToDisplay)
    {
        //display a panel or something that dispalys a warning to the player about them not allowed

        //set active a worldspace canvas
        warningPanel.SetActive(true);

        yield return new WaitForSeconds(timeToDisplay);

        warningPanel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //start allow pushback until the player leaves
        playerIsColliding = true;
        //get the player
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            //add force to the player
            StartCoroutine(Pushback(player));
            StartCoroutine(DisplayDoorPanelWarning(displayTimerAmount));
            Debug.Log("Pushing Player");
        }
        Debug.Log("colliding with something");
    }

    private void OnTriggerExit(Collider other)
    {
        //if the player has left, stop the collision
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("stopped colliding");
            playerIsColliding = false;
        }
    }
}
