using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCollection : MonoBehaviour
{
    // disapear the object, allow for the end of level, change the quest line that's showing, and add to a count in player data of how many chips have been collected
    // use number of chips to determine the questline

    [SerializeField] private GameObject firstLine; // first objective line
    [SerializeField] private GameObject secondLine; // second objective line

    void Start()
    {
        firstLine.SetActive(true);
        secondLine.SetActive(false);
        transform.gameObject.SetActive(true);
    }

    void OnTriggerEnter()
    {
        firstLine.SetActive(false);
        secondLine.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
