using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.LEGO.Minifig;
using System.Linq;

public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    // Use Update method to set destination to player with highest pumpkin count
    void Update() {
        GameObject maxPlayer = players.Aggregate((p1,p2) => p1.GetComponent<MinifigController>().pumpkinCount > p2.GetComponent<MinifigController>().pumpkinCount ? p1 : p2);
        agent.SetDestination(maxPlayer.transform.position);
    }
    // Reset pumpkin count of player on collision
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            var controller = other.GetComponent<MinifigController>();
            controller.pumpkinCount = 0;
        }
    }
}
