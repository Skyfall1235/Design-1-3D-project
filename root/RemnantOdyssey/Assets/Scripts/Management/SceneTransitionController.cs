using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour
{
    #region Variables
    [Header("Scene Transition Scriptable Object")]
    [SerializeField] SO_SceenTrans screenTransObject;

    [SerializeField] SO_Player playerData;

    [Header("Scene Status")]
    [SerializeField] private string currentScene;
    [Tooltip("If true, the next scene is currently being loaded.")]
    [SerializeField] private bool isLoadingNextScene;
    [Space]

    [Header("Transition UI Elements")]
    // The actual transition canvas
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject loadingCanvas;
    [Tooltip("The name of the scene that is currently being loaded.")]
    [SerializeField] TextMeshProUGUI visibleSceneName;
    [Tooltip("A brief description of the scene that is currently being loaded.")]
    [SerializeField] TextMeshProUGUI visibleSceneDescription;
    [Tooltip("An image that represents the transition between scenes.")]
    [SerializeField] Image visibleTransitionImage;
    #endregion

    //sets up the dictionary
    private void Awake()
    {
        //the call below stores the dictionary of the
        screenTransObject.InitialiseTransitionDictionary();

        //the real method to set up everything
        currentScene = SceneManager.GetActiveScene().name;
        //playerData.currentLevel = currentScene;
    }
    public void LoadScene(string selectedSceneName)
    {
        Transitions chosenScene;
        if (screenTransObject.transitionDictionary.TryGetValue(selectedSceneName, out chosenScene))
        {
            //set active the loading panel
            loadingCanvas.SetActive(true);
            GlobalMethods.PlaySoundAtLocation(SoundType.Music, "loading scene", 2, gameObject.GetComponent<AudioSource>(), 1);
            //display the bar and the text
            visibleSceneName.text = chosenScene.sceneName;
            visibleSceneDescription.text = chosenScene.sceneDescription;
            //visibleTransitionImage.sprite = chosenScene.transitionImage.sprite;

            //start the coroutine
            StartCoroutine(LoadSceneAsync(selectedSceneName));
            isLoadingNextScene = true;
            
            //now, take data fron chosenscene and populate the UI

            Debug.Log($"scene loading sucessfully");
        }
        else
        {
            Debug.LogWarning("Scene " + selectedSceneName + " was not found");
        }
    }
    public void ReturnToMainMenu()
    {
        //get current scene, open up next transisition, and begin async unload and then async load
    }

    //coroutine to handle transition
    private IEnumerator LoadSceneAsync(string sceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            float progressValue = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progressValue;
            yield return null;
        }
        loadingCanvas.SetActive(false);
    }
}
