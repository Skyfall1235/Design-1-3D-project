using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SettingData", menuName = "ScriptableObjects/Game Management/PlayerSettings")]
[System.Serializable]

public class SO_SettingData : ScriptableObject
{
    [Header("Audio")]
    [SerializeField] public float musicVolume = 1f;
    [SerializeField] public float soundEffectVolume = 1f;
    [Header("Screen")]
    [SerializeField] public bool fullScreen = true;
    [SerializeField] public PCResolution resolution = PCResolution.Resolution1080p;
    [Header("Screen Technical")]
    [SerializeField] public float playerCameraFOV;
    [SerializeField] public float screenBrightness;
    [SerializeField] public float mouseSensitivity;

}
