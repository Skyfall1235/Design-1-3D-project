using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    // Show text when player is near enough to the interactable panel, and if not near enough hid the text and become a highlighted material
    // If you're using a different material than the test just duplicate it and make it emissive to desired color
    
    // Vars
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject panelObj;
    [SerializeField] private Material originalMat;
    [SerializeField] private Material highlightMat;

    private bool canInteract;

    void Start()
    {
        // should work as long as the player isn't spawned directly it the trigger
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
        canInteract = false;
    }

    private void OnTriggerEnter(Collider obj)
    {
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = true;
        panelObj.GetComponent<Renderer>().material = originalMat;
        canInteract = true;
    }

    private void OnTriggerExit(Collider obj)
    {
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
        canInteract = false;
    }

    private void Interact()
    {
        print("Player has interacted with object");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Interact();
        } else if (Input.GetKeyDown(KeyCode.E) && canInteract == false) {
            print("Player is not close enough to interact");
        }
    }
}
