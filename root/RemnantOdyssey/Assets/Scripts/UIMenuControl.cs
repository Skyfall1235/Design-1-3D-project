using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIMenuControl : MonoBehaviour
{
    // This is basically going to be a bunch of input controls for different UI panels that will exist on the player prefab, so they are always accessible

    [SerializeField] private KeyCode interactionMenuKey;
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private KeyCode mapKey;
    [SerializeField] private bool mapOpen;
    [SerializeField] private bool pauseMenuOpen;
    [SerializeField] private bool interactionMenuOpen;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject interactionPanel;

    private void Update()
    {
        if (Input.GetKeyDown(mapKey))
        {
            // Toggle the bool
            mapOpen = !mapOpen;
            Map(mapOpen);
        }
        if (Input.GetKeyDown(pauseKey))
        {
            // Toggle the bool
            pauseMenuOpen = !pauseMenuOpen;
            Pause(pauseMenuOpen);
        }
        if (Input.GetKeyDown(interactionMenuKey))
        {
            // Toggle the bool
            interactionMenuOpen = !interactionMenuOpen;
            InteractionMenu(interactionMenuOpen);
        }
    }

    // Control the toggle and allow interaction with the menu
    private void Map(bool toggle)
    {
        // Code to handle the map UI
        if (toggle)
        {
            //open the menu, and allow interaction
            mapPanel.SetActive(true);
        }
        else
        {
            //Close the menu, and disallow interaction
            mapPanel.SetActive(false);
        }
    }

    private void Pause(bool toggle)
    {
        // Code to handle the pause menu UI
        if (toggle)
        {

        }
        else
        {

        }
    }

    private void InteractionMenu(bool toggle)
    {
        // Code to handle the interaction menu UI
        if (toggle)
        {

        }
        else
        {

        }
    }
}
