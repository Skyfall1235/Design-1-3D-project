using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Transitions
{
    //do i need scene name here again?
    [SerializeField] public string sceneName;
    [SerializeField] public string sceneDescription;
    [SerializeField] public Image transitionImage;
}
[System.Serializable]
public struct MiniMapInfo
{
    //do not use this scene name
    //WRONG AGAIN USE THE SCENE NAME BABY
    [SerializeField] public string mapName;
    [SerializeField] public Image baseMap;
    [SerializeField] public List<Image> mapCover;
    [SerializeField] public List<bool> mapCoverDisplayed;
    [SerializeField] public List<Image> questMarker;
    [SerializeField] public List<Image> itemMarker;
}
[System.Serializable]
public struct Sounds
{
    //collection name is for referring in the inspector. please use the soundName string when required
    [SerializeField] public string collectionName;
    //soudfile should be the onl;y accessible part
    [SerializeField] public List<AudioClip> soundFile;
}
