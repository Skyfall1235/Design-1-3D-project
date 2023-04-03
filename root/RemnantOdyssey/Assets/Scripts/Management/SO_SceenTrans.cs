using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransistionScriptableObject", menuName = "ScriptableObjects/Game Management/Transitions")]
[System.Serializable]
public class SO_SceenTrans : ScriptableObject
{
    [SerializeField] private string[] sceneNames;
    [SerializeField] private List<Transitions> transitionData = new List<Transitions>();

    public Dictionary<string, Transitions> transitionDictionary = new Dictionary<string, Transitions>();

    // Move the code that sets the dictionary to a method or constructor
    public void InitialiseTransitionDictionary()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
            Debug.Log(sceneNames[i]);
            Debug.Log(transitionData[i]);
            transitionDictionary.Add(sceneNames[i], transitionData[i]);
        }
        //for debugging
        foreach (var pair in transitionDictionary)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
}
