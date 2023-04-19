using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Player : SO_Character
{
    //curent scene
    public string currentLevel;

    //ireccommend looking at what get/set does, its very useful

    //player health
    public int playerHealth
    { 
        get => Health; 
        set => Health = value;
    }
    public int playerHealthMax
    {
        get => HealthMax;
        set => HealthMax = value;
    }

    //player defense
    public int playerDefense
    { 
        get => Defense; 
        set => Defense = value;
    }

    //if a player has energy?
    public int playerEnergy
    {
        get => Energy;
        set => Energy = value;
    }

    //the players position
    public Vector3 playerPosition
    {
        get => Position;
        set => Position = value;
    }
}
