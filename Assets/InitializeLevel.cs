using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawnPoints;
    [SerializeField]
    private GameObject playerPrefab;

    private void Start() {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        Debug.Log(playerConfigs.Length);
        for(int i = 0; i < playerConfigs.Length; i++){
            Debug.Log("HALLO"+i);
            var player = Instantiate(playerPrefab, playerSpawnPoints[i].position, playerSpawnPoints[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
        }

    }
}
