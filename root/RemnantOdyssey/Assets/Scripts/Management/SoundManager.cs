using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //sound name to
    [SerializeField] private List<string> soundName;
    [SerializeField] private List<Sounds> soundFiles;
    private Dictionary<string, Sounds> sound = new Dictionary<string, Sounds>();



    //use a dictionary and combine the 2 during load
    private void Awake()
    {
        SetUpDictionary();
    }

    //sets up the dictionary
    private void SetUpDictionary()
    {
        for (int i = 0; i < soundName.Count; i++)
        {
            sound.Add(soundName[i], soundFiles[i]);
        }

        //to confirm every soundname has a file

        foreach (var pair in sound)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }

    //play sound, at sound location
    public void PlaySoundAtLocation(string soundName, int indexLocation, AudioSource source)
    {
        Sounds chosenStruct;
        AudioClip chosenSound;
        if (sound.TryGetValue(soundName, out chosenStruct))
        {
            source.PlayOneShot(chosenSound);
            Debug.Log($"Sound {soundName} played successfully");
        }
        else
        {
            Debug.LogWarning("Sound " + soundName + "was not found in dictionary 'sounds'");
        }
    }


    //trigger animation with sound






}
