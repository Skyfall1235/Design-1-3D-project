using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniMapScriptableObject", menuName = "ScriptableObjects/Player/MiniMap")]
[System.Serializable]
public class SO_MiniMap : ScriptableObject
{
    [SerializeField] private List<MiniMapInfo> mapData = new List<MiniMapInfo>();

    public Dictionary<string, MiniMapInfo> miniMapDictionary = new Dictionary<string, MiniMapInfo>();

    public void InitialiseTransitionDictionary()
    {
        for (int i = 0; i < mapData.Count; i++)
        {
            Debug.Log(mapData[i].mapName);
            Debug.Log(mapData[i]);
            miniMapDictionary.Add(mapData[i].mapName, mapData[i]);
        }
        //for debugging
        //foreach (var pair in miniMapDictionary)
        //{
        //    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        //}
    }
}
