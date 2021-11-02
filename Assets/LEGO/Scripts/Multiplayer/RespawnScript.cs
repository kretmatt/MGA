using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField]
    private List<Transform> respawnPoints = new List<Transform>();

    void OnTrigger(Collider other){   
        Debug.Log("TETSTSTST");   
        if(other.CompareTag("Player")){
            var character = other.GetComponent<Transform>();
            character.transform.position = respawnPoints[Random.Range(0, respawnPoints.Count)].transform.position;
        }
    }
}
