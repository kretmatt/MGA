using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.LEGO.Behaviours.Actions;

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
        whatToSpawnClones.RemoveAll(clone=>clone==null);
        if(whatToSpawnClones.Count<3){
            GameObject newPumpkin = (Instantiate(whatToSpawnPrefab, spawnLocations[index].transform.position, Quaternion.Euler(0,0,0)) as GameObject);

            whatToSpawnClones.Add(newPumpkin);

            index++;
            if(index>=spawnLocations.Length)
                index=0;
        }
    }

    void PickUpPumpkin(GameObject gobject){
        whatToSpawnClones.Remove(gobject);
        Destroy(gobject);
    }
}
