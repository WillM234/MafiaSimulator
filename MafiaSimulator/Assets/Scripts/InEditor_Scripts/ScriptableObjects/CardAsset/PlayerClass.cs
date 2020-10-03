using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : ScriptableObject
{
    [Header("Player Starting Loadout")]
    private PlayerClass playerClass;
    public bool wasBouncer, wasAccountant, wasFarmer;
    public float starting_Currency,starting_Athletics,Starting_Persuasion,Starting_Mobility;
    public string PlayerClassName;
    public PlayerClass(PlayerClass playerClass)
    {
        this.playerClass = playerClass;
    }
}