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
    [SerializeField] private bool ableToBeInteracted;
    [SerializeField] private GameObject gameManager;
    private UIMenuControl menuControl;
    [SerializeField] private GameObject interactable;

    private bool canInteract;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        menuControl = gameManager.GetComponent<UIMenuControl>();
        // should work as long as the player isn't spawned directly it the trigger
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
        canInteract = false;
    }
    public void Interact()
    {
        if(ableToBeInteracted && menuControl.isInteracting)
        {
            Debug.Log(menuControl.isInteracting);
            Debug.Log("is doing action");
            //display some prompt on the UI, and look for the 
            DoAction();
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        Interact();
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = true;
        panelObj.GetComponent<Renderer>().material = originalMat;
        ableToBeInteracted = true;

    }

    private void OnTriggerExit(Collider obj)
    {
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
        ableToBeInteracted = false;
    }
    private void DoAction()
    {
        Debug.Log("is doing action");
        MagneticWall2 magneticWall = interactable.GetComponent<MagneticWall2>();
        //only turns it off its if on
        Debug.Log((magneticWall != null, magneticWall.PowerStateOn));
        if (magneticWall != null && magneticWall.PowerStateOn)
        {
            // toggle the PowerStateOn variable
            magneticWall.PowerStateOn = !magneticWall.PowerStateOn;
            return;
        }
        Debug.Log("didnt find a script");

    }
}
