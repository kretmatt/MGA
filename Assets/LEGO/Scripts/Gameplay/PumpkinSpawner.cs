using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PumpkinSpawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject whatToSpawnPrefab;
    public List<GameObject> whatToSpawnClones;

    int index=0;

    void Start(){
        InvokeRepeating("SpawnPumpkin",5.0f,15.0f);
    }

    void SpawnPumpkin(){
        if(whatToSpawnClones.Count==7)
            whatToSpawnClones.Remove(whatToSpawnClones.FirstOrDefault());
        whatToSpawnClones.Add(Instantiate(whatToSpawnPrefab, spawnLocations[index].transform.position, Quaternion.Euler(0,0,0)) as GameObject);
        index++;
        if(index==spawnLocations.Length)
            index=0;
    }
}
