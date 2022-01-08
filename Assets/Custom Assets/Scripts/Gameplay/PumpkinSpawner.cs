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
    public AudioSource soundEffect;
    public float spawnFrequency = 5.0f;

    int index=0;

    void Start(){
        var players = GameObject.FindGameObjectsWithTag("Player");
        spawnFrequency -=(players.Length)*1.2f;
        InvokeRepeating("SpawnPumpkin",5.0f,spawnFrequency);
    }

    void SpawnPumpkin(){
        whatToSpawnClones.RemoveAll(clone=>clone==null);
        if(whatToSpawnClones.Count<3){
            StartCoroutine(SpawnPumpkinAsync());
            index++;
            if(index>=spawnLocations.Length)
                index=0;
        }
    }

    IEnumerator SpawnPumpkinAsync(){
        GameObject newPumpkin = (Instantiate(whatToSpawnPrefab, spawnLocations[index].transform.position, Quaternion.Euler(0,0,0)) as GameObject);
        whatToSpawnClones.Add(newPumpkin);
        soundEffect.Play();
        yield return new WaitForSeconds(1);
    }
}
