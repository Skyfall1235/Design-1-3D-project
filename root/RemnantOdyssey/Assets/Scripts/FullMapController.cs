using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullMapController : MonoBehaviour
{
    private void Start()
    {
        HandleMapBounds();
    }

    //the plan of this is to get the current minimap, display the unlocked areas, and move the map around/zoom in to get a better view at the area.


    //getting the minimap from the current info





    //Display the unlocked areas





    // Get a reference to the RectTransform of the base maps' component
    [SerializeField] private RectTransform rectTransformOfMap;
    // Get a reference to the RectTransform of the borders' component
    [SerializeField] private RectTransform rectTransformOfMapBorder;

    // Get a reference to the canvas scaler component
    [SerializeField] private CanvasScaler canvasScaler;


    //Move the map around and zoom/ handle other UI inputs?
    private void HandleMapBounds()
    {


        // Set the minimum size of the RectTransform to be the same as the canvas scaler's reference resolution
        rectTransformOfMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasScaler.referenceResolution.x);
        rectTransformOfMap.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasScaler.referenceResolution.y);
        //set the minimum size of the border/legend to fit as well
        rectTransformOfMapBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasScaler.referenceResolution.x);
        rectTransformOfMapBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasScaler.referenceResolution.y);
    }




}
