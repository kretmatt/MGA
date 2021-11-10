using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;

public class VictoryScript : MonoBehaviour
{
    //Game time
    public float timeRemaining = 10;
    // Amount of pumkins for player win condition
    public int neededPumpkins=1;
    
    public bool timerIsRunning=false;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning){
            if(timeRemaining>0){
                timeRemaining-=Time.deltaTime;
            }else{
                int currPumpkins=0;
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach(GameObject gobject in players){
                    currPumpkins+=gobject.GetComponent<MinifigController>().pumpkinCount;
                }
                if(currPumpkins>=neededPumpkins)
                {
                    // Load player win scene
                    Debug.Log("PLAYER WIN");
                }else{
                    // Load hunter win scene
                    Debug.Log("HUNTER WINs");
                }
                timerIsRunning=false;
            }
        }
        
    }


    void EndGame(){

    }
}
