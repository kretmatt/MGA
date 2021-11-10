using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RespawnScript : MonoBehaviour
{
    [SerializeField]
    private List<Transform> respawnPoints = new List<Transform>();

    void OnDeathRespawn(GameObject playerToRespawn){   
        var playerIHandler = playerToRespawn.GetComponent<PlayerInputHandler>();
        if(playerToRespawn.CompareTag("Player")){
            var character = playerToRespawn.GetComponent<Transform>();
            character.transform.position = respawnPoints[Random.Range(0, respawnPoints.Count)].transform.position;
        }
    }
}
