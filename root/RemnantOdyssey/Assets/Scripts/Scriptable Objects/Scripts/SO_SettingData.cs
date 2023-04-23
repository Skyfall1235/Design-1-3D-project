using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SettingData", menuName = "ScriptableObjects/Game Management/PlayerSettings")]
[System.Serializable]

public class SO_SettingData : ScriptableObject
{
    [Header("Audio")]
    [SerializeField] public float musicVolume;
    [SerializeField] public float soundEffectVolume;
    [Header("Screen")]
    [SerializeField] public bool fullScreen = true;
    [SerializeField] public PCResolution resolution;
    [Header("Screen Technical")]
    [SerializeField] public float playerCameraFOV;
    [SerializeField] public float screenBrightness;
    [SerializeField] public float mouseSensitivity;

}
