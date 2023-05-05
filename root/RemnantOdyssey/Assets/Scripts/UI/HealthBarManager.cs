using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private SO_Player playerData;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Image healthFill;
    [SerializeField] private Image energyFill;
    [SerializeField] private Gradient healthGradient;
    [SerializeField] private Gradient energyGradient;
    [SerializeField] private Image powerIndicator;

    [Header("Functionality")]
    [SerializeField] private int functHealth;
    [SerializeField] private int functMaxHealth;
    [SerializeField] private int functEnergy;
    [SerializeField] private int functEnergyMax;

    
    // For in game health over enemies, change canvas to World Spcae in render mode and resize the canvas over the enemy
    public void SetMaxStat(Slider slider, Image fill, int stat, Gradient gradient)
    {
        slider.maxValue = stat;
        slider.value = stat;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetStat(Slider slider, Image fill, int stat, Gradient gradient)
    {
        slider.value = stat;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void OnOffIndicator(bool isOn)
    {
        if(isOn)
        {
            powerIndicator.color = new Color(0.35f, 1f, 0.35f, 1f);
        } else {
            powerIndicator.color = new Color(1f, 0.4f, 0.35f, 1f);
        }
    }
    private void UpdateFuncts()
    {
        functHealth = playerData.playerHealth;
        functEnergy = playerData.playerEnergy;
    }

    void Start()
    {
        SetMaxStat(healthSlider, healthFill, functMaxHealth, healthGradient);
        SetMaxStat(energySlider, energyFill, functEnergyMax, energyGradient);
        functMaxHealth = playerData.playerHealthMax;
        functEnergyMax = playerData.playerEnergyMax;
        functHealth = functMaxHealth;
        functEnergy = functEnergyMax;

        OnOffIndicator(true);
    }

    void Update()
    {

        UpdateFuncts();
        //for testing
        if (Input.GetKeyDown(KeyCode.J))
        {
            functHealth -= 1;
            SetStat(healthSlider, healthFill, functHealth, healthGradient);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            functHealth += 1;
            SetStat(healthSlider, healthFill, functHealth, healthGradient);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            functEnergy -= 1;
            SetStat(energySlider, energyFill, functEnergy, energyGradient);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            functEnergy += 1;
            SetStat(energySlider, energyFill, functEnergy, energyGradient);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            OnOffIndicator(false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OnOffIndicator(true);
        }
        //links to the player data
        if (playerData.playerPowerOn)
        {
            OnOffIndicator(true);
        }
        else
        {
            OnOffIndicator(false);
        }
    }
}
