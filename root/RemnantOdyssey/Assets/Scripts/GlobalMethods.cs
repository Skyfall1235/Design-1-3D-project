using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalMethods
{
    public static void PlaySoundAtLocation(string soundName, int indexLocation, AudioSource source)
    {
        SoundManager soundManager = FindSoundManager();
        if (soundManager != null)
        {
            // Call the PlaySoundAtLocation method on the SoundManager component
            soundManager.PlaySoundAtLocation(soundName, indexLocation, source);
        }
        else
        {
            Debug.LogWarning("Could not play sound. SoundManager not found.");
        }

    }
    #region Finding Relevent Objects
    private static SoundManager FindSoundManager()
    {
        // Find the GameManager object in the scene
        GameObject gameManager = GameObject.Find("GameManager");
        //for storing the soundmanager
        SoundManager soundManager;

        if (gameManager != null)
        {
            // Get the SoundManager component attached to the GameManager object
            try
            {
                return gameManager.GetComponent<SoundManager>();
            }
            catch (Exception ex)
            {
                //i think i nedd to use a try/catch here?
                Debug.LogError("Could not find SoundManager component on GameManager." + ex.Message + " StackTrace: " + ex.StackTrace);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Could not find GameManager object in scene.");
            return null;
        }
    }

    #endregion
}
    

