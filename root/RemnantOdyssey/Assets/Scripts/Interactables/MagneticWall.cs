using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticWall : MonoBehaviour
{
    //link to the player data to see if the player has turned it off
    [Header("Force Data")]
    //force to push against the player
    [SerializeField] private float appliedForce;
    [SerializeField] private float displayTimerAmount;
    private bool playerIsColliding;

    [Header("World Space UI")]
    [SerializeField] GameObject displayCanvas;
    [SerializeField] GameObject warningPanel;
    [SerializeField] GameObject welcomePanel;

    private void Update()
    {

    }

    private IEnumerator Pushback(GameObject GO_player, Rigidbody playerRB)
    {
        while(playerIsColliding)
        {
            //gets the players proximity
            Vector3 direction = GO_player.transform.position - transform.position;
            float distance = direction.magnitude;
            float forceMagnitude = appliedForce / distance;
            Vector3 force = direction.normalized * forceMagnitude;
            playerRB.AddForce(force);
            //allows for a frame to pass
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
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            //add force to the player
            StartCoroutine(Pushback(player, playerRB));
            StartCoroutine(DisplayDoorPanelWarning(displayTimerAmount));
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if the player has left, stop the collision
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            if (other == player)
            {
                playerIsColliding = false;
            }
        }
    }
}
