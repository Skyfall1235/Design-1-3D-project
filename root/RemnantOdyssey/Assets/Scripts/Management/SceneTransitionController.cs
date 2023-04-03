using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct transitions
{
    [SerializeField] public string sceneName;
    [SerializeField] public string sceneDescription;
    [SerializeField] public Image transitionImage;
}

public class SceneTransitionController : MonoBehaviour
{
    [SerializeField] private string[] sceneNames;
    [SerializeField] private string currentScene;
    [SerializeField] private bool isLoadingNextScene;
    [SerializeField] private List<transitions> transitionData;
    private Dictionary<string, transitions> transitionDictionary;

    //the actual transition canvas
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] TextMeshProUGUI visibleSceneName;
    [SerializeField] TextMeshProUGUI visibleSceneDescription;
    [SerializeField] Image visibleTransitionImage;

    //sets up the dictionary
    private void Awake()
    {
        //set the dictionary full of structs
        for (int i = 0; i < sceneNames.Length; i++)
        {
            transitionDictionary.Add(sceneNames[i], transitionData[i]);
        }

        //to confirm every soundname has a file

        foreach (var pair in transitionDictionary)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }

    public void LoadScene(string selectedSceneName)
    {
        transitions chosenScene;
        if (transitionDictionary.TryGetValue(selectedSceneName, out chosenScene))
        {
            //set active the loading panel
            loadingCanvas.SetActive(true);
            //display the bar and the text
            visibleSceneName.text = chosenScene.sceneName;
            visibleSceneDescription.text = chosenScene.sceneDescription;
            visibleTransitionImage = chosenScene.transitionImage;
            //start the coroutine
            StartCoroutine(LoadSceneAsync(selectedSceneName));
            //now, take data fron chosenscene and populate the UI

            Debug.Log($"scene loading sucessfully");
        }
        else
        {
            Debug.LogWarning("Scene " + chosenScene + " was not found");
        }
    }
    public void ReturnToMainMenu()
    {
        //get current scene, open up next transisition, and begin async unload and then async load
    }


    private IEnumerator LoadSceneAsync(string sceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            float progressValue = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            progressBar.value = progressValue;
            yield return null;
        }
    }


    //coroutine to handle transition
    //display an image, maybe gif, handle a loading bar or spinner, name level, and some flavor text

    //the order
    //display gif, unload previous scene, (show canvas with name level, and flavor text), load new scene, once done destroy canvas

}
