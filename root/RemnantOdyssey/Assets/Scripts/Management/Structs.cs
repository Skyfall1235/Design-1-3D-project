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
    [SerializeField] public string mapName;
    [SerializeField] public Image baseMap;
    [SerializeField] public List<Image> mapCover;
    [SerializeField] public List<bool> mapCoverDisplayed;
    [SerializeField] public List<Image> questMarker;
    [SerializeField] public List<Image> itemMarker;
}
