using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIActions : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private bool SettingIsOpen;
    #region button Commands
    // Here to just hold all the button click info
    public void PlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsButtonClick()
    {
        // open settings
    }

    public void QuitButtonClick()
    {
        Application.Quit();
    }
    #endregion

    private void Start()
    {
        GlobalMethods.PlaySoundAtLocation(SoundType.Music, "Menu Music", 0, menu.GetComponent<AudioSource>(), 1f);
    }


}
