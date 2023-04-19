using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager
{
    //this needs to be able to access the scriptable object for each enemy, and perform metohds on them



    //take damage method
    private void TakeDamage(SO_Character charData, int DamageAmount)
    {
        charData.Health -= DamageAfterDefense(charData, DamageAmount);
    }

    //calculate defense from an attack
    private int DamageAfterDefense(SO_Character charData, int DamageBeforeReduction)
    {
        //return the
        return (DamageBeforeReduction * (charData.Defense / 100));  
    }

    //ability to heal
    private int CalculateHeal(SO_Character charData, int HealPercent)
    {
        //for debugging
        int damageTaken = charData.HealthMax - charData.Health;
        //actual heal calculations. i hope the typecasting works
        float healEquation = HealPercent / 100;
        int product = (int) (charData.HealthMax * healEquation);
        return product;
    }
}
