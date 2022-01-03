using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool Ready { get; set;}
    public GameObject PlayerPrefab { get; set; } 
}
