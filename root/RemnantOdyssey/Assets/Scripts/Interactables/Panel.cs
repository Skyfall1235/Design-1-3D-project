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

    void Start()
    {
        // should work as long as the player isn't spawned directly it the trigger
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
    }

    private void OnTriggerEnter(Collider obj)
    {
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = true;
        panelObj.GetComponent<Renderer>().material = originalMat;
    }

    private void OnTriggerExit(Collider obj)
    {
        // if the obj is player:
        canvas.GetComponent<Canvas>().enabled = false;
        panelObj.GetComponent<Renderer>().material = highlightMat;
    }
}
