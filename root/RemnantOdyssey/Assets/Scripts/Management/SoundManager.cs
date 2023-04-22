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
    public void PlaySoundAtLocation(string soundName, int indexLocation, AudioSource source, float volume)
    {
        Sounds chosenStruct;
        AudioClip chosenSound;
        if (audioFiles.sound.TryGetValue(soundName, out chosenStruct))
        {
            chosenSound = chosenStruct.soundFile[indexLocation];
            source.PlayOneShot(chosenSound, volume);
            Debug.Log($"Sound {soundName} played successfully");
        }
        else
        {
            Debug.LogWarning("Sound " + soundName + "was not found in dictionary 'sounds'");
        }
    }
    //find the gameobject, then get the component Soundamanger, then use the method PlaySoundAtLocation(name, index, source)


    //trigger animation with sound

    // Temp Functionality

}
