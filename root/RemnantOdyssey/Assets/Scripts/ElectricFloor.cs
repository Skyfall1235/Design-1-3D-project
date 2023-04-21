using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFloor : MonoBehaviour
{
    //needs to detect when an object is near it to start showing animation
    //needs to deal damage/kill
    //needs an idle playing that doesnt use a lot of computer power

    //contraints - distance from player, damage dealt, sounds, if its on or off, and toggling that.
    //if oscillating, give time contraints


    //animator, sounds, the trigger/ collider(covered by the attached object), the toggle bool

    [SerializeField] bool toggleActivity; //true means its on
    [Space]
    [Header("Particle & Audio")]
    [SerializeField] AudioSource objectSoundSource;
    [SerializeField] ParticleSystem particleSys;


    //oscillation control
    [Header("Oscillation Control")]
    [SerializeField] bool objectOscillates;
    [SerializeField] float oscillationFrequency;

    private void Start()
    {
        if (toggleActivity && objectOscillates)
        {
            //check if it oscilates.
            OscillatePower();
        }
        else if (toggleActivity)
        {
            //if it doesnt oscillate but it is on
            ToggleActivityOfObject(true);
        }
        return;
    }

    //public for other items to interface with
    public void ToggleActivityOfObject(bool input)
    {
        toggleActivity = input;
    }

    //oscilation code
    void OscillatePower()
    {
        //runs the oscillate coroutine, maybe triggers animations or
        StartCoroutine(Oscillate());
    }
    IEnumerator Oscillate()
    {
        while(toggleActivity)
        {
            //turns on the object, waits some amount of time, then turns off
            
            yield return new WaitForSeconds(oscillationFrequency / 2);
            
            yield return new WaitForSeconds(oscillationFrequency / 2);
        }
        yield return null;
    }
    bool triggerControl = false;
    private void OnTriggerEnter(Collider other)
    {
        if(triggerControl)
        {
            other.gameObject.GetComponent<HealthManager>().Shock();
        }
        //else just do nothing
    }
}
