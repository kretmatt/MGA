using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawnPoints;

    private void Start() {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs();
        int i = 0;
        foreach(PlayerConfiguration pc in playerConfigs){
            pc.Input.GetComponent<PlayerInputHandler>().InitializePlayer(pc, playerSpawnPoints[i]);
            i++;
        }
    }
}
