using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Temp Functionality

public class SoundManager : MonoBehaviour
{
    SO_AudioFiles audioFiles;
    //use a dictionary and combine the 2 during load
    private void Awake()
    {
        audioFiles.SetUpDictionary();
    }
    //play sound, at sound location
    public void PlaySoundAtLocation(string soundName, int indexLocation, AudioSource source)
    {
        Sounds chosenStruct;
        AudioClip chosenSound;
        if (audioFiles.sound.TryGetValue(soundName, out chosenStruct))
        {
            chosenSound = chosenStruct.soundFile[indexLocation];
            source.PlayOneShot(chosenSound);
            Debug.Log($"Sound {soundName} played successfully");
        }
        else
        {
            Debug.LogWarning("Sound " + soundName + "was not found in dictionary 'sounds'");
        }
    }


    //trigger animation with sound

    // Temp Functionality
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlaySoundAtLocation("Main_Menu_Music", audiosource);
        }
    }

    public void OnMenuButtonClick()
    {
        PlaySoundAtLocation("Main_Menu_Button", audiosource);
    }

    public void OnMenuButtonHighlight()
    {
        PlaySoundAtLocation("Main_Menu_Highlight", audiosource);
    }


}
