using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;
using UnityEngine.SceneManagement;
using Unity.LEGO.Game;


public class VictoryScript : MonoBehaviour
{
    //Game time
    public float timeRemaining = 10;
    // Amount of pumkins for player win condition
    public int neededPumpkins=1;
    
    public bool timerIsRunning=false;

    public int overallPumpkinCount = 0;

    GameObject[] players;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning){
            if(timeRemaining>0){
                timeRemaining-=Time.deltaTime;
            }else{
                int currPumpkins=0;
                foreach(GameObject gobject in players){
                    currPumpkins+=gobject.GetComponent<MinifigController>().pumpkinCount;
                }
                if((overallPumpkinCount + currPumpkins)>=neededPumpkins)
                {
                    // Load player win scene
                    SceneManager.LoadScene("Results");
                    WinnerStorage.WinnerRole = "Collector team";
                }else{
                    // Load hunter win scene
                    SceneManager.LoadScene("Results");
                    WinnerStorage.WinnerRole = "Hunter";
                }
                timerIsRunning=false;
            }
        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            var controller = other.GetComponent<MinifigController>();
            overallPumpkinCount += controller.pumpkinCount;
            controller.pumpkinCount = 0;
        }
    }
}
