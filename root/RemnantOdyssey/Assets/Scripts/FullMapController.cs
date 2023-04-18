using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMapController : MonoBehaviour
{
    //rect transforms
    [SerializeField] private RectTransform rectTransformOfMap;
    [SerializeField] private RectTransform rectTransformOfMapBorder;
    [SerializeField] private RectTransform canvasRect;
    // Get a reference to the canvas scaler component
    [SerializeField] private CanvasScaler canvasScaler;
    //reference to the map object iself
    [SerializeField] private GameObject map;
    //control fields
    [SerializeField] private float zoomLevel = 1.0f;
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float minZoom = -1f;
    [SerializeField] private float maxZoom = 1f;
    [SerializeField] private float minZoomScale = 0.5f;
    [SerializeField] private float maxZoomScale = 2f;
    [SerializeField] private float deadzoneRadius = 100f;
    private void Start()
    {
        SetupMapBounds();
    }
    private void Update()
    {
        MoveMap();
        DirectionFromCenter();
        AdjustZoomLevel();
        
    }
    #region stuff to do
    //the plan of this is to get the current minimap, display the unlocked areas, and move the map around/zoom in to get a better view at the area.


    //getting the minimap from the current info
    //retrieve the current map from the data sheet and save it every time the scene starts


    //Display the unlocked areas
    //get the list of currently locked covers, and update the display to show which ones are which
    #endregion


   //I STG I BET THIS DAMN THING IS THE PROBLEM
    private void MoveMap()
    {
        Vector2 directionFromCenter = DirectionFromCenter().normalized;
        Vector2 position = rectTransformOfMap.anchoredPosition;



        // Check if the camera is within the deadzone
        if (DistanceFromCenter() < deadzoneRadius)
        {
            return;
        }
        if (DetermineIfPanelIsTooFar())
        {
            return;
        }


        // Calculate the distance to move the panel
        float distance = directionFromCenter.magnitude * Time.deltaTime * 1000f;

        // Move the panel in the opposite direction of the mouse
        position -= directionFromCenter * distance;

        // Set the position of the panel
        rectTransformOfMap.anchoredPosition = position;
    }

    private void AdjustZoomLevel()
    {
        // Get the scroll wheel input
        float scrollDelta = Input.mouseScrollDelta.y;

        // Adjust the zoom level based on the scroll wheel input
        zoomLevel += scrollDelta * zoomSpeed * Time.deltaTime;

        // Clamp the zoom level to the allowed range
        zoomLevel = Mathf.Clamp(zoomLevel, minZoom, maxZoom);

        // Calculate the new scale factor based on the zoom level
        float scaleFactor = Mathf.Lerp(minZoomScale, maxZoomScale, zoomLevel);

        // Scale the RectTransform of the canvas
        rectTransformOfMap.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
    }
    //this should be good
    private void SetupMapBounds()
    {
        // Set the minimum size of the RectTransform to be the same as the canvas scaler's reference resolution
        rectTransformOfMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasScaler.referenceResolution.x);
        rectTransformOfMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasScaler.referenceResolution.y);
        //set the minimum size of the border/legend to fit as well

        //rectTransformOfMapBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasScaler.referenceResolution.x);
        //rectTransformOfMapBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasScaler.referenceResolution.y);
    }

    #region returning Methods
    private Vector3 DirectionFromCenter()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 mousePosition = Input.mousePosition;
        Vector2 directionFromCenter = (mousePosition - screenCenter).normalized;

        //Debug.Log(directionFromCenter);
        return directionFromCenter;
    }
    private float DistanceFromCenter()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 mousePosition = Input.mousePosition;
        float distanceFromCenter = Vector2.Distance(screenCenter, mousePosition);
        return distanceFromCenter;
    }

    //LOOK THIS OVER

    private bool DetermineIfPanelIsTooFar()
    {
        Vector2 objPosition = map.transform.position;
        Vector2 canvasSize = canvasScaler.referenceResolution;

        float minX = -canvasSize.x / 2f;
        float maxX = canvasSize.x / 2f;
        float minY = -canvasSize.y / 2f;
        float maxY = canvasSize.y / 2f;

        if (objPosition.x < minX || objPosition.x > maxX || objPosition.y < minY || objPosition.y > maxY)
        {
            return true;
        }

        return false;
    }
    #endregion
}
