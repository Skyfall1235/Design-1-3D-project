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
