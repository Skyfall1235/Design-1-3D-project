using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Enemy : SO_Character
{
    public int enemyHealth
    {
        get => Health;
        set => Health = value;
    }
    public int enemyHealthMax
    {
        get => HealthMax;
        set => HealthMax = value;
    }

    //player defense
    public int enemyDefense
    {
        get => Defense;
        set => Defense = value;
    }

    //if a player has energy?
    public int enemyEnergy
    {
        get => Energy;
        set => Energy = value;
    }

    //the players position
    public Vector3 enemyPosition
    {
        get => Position;
        set => Position = value;
    }
}
