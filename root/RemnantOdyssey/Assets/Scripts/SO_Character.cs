using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Character : ScriptableObject
{
    //current HP
    public int Health;
    //the max health of any object
    public int HealthMax;
    //a defense value
    public int Defense;
    //if the object needs energy
    public int Energy;
    //the characters position
    public Vector3 Position;
}
