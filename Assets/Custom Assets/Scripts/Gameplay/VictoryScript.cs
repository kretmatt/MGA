using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Minifig;
using UnityEngine.SceneManagement;
using Unity.LEGO.Game;
using UnityEngine.UI;
using TMPro;
using System;


public class VictoryScript : MonoBehaviour
{
    //Game time
    public float timeRemaining = 10;
    // Amount of pumkins for player win condition
    public int neededPumpkins=1;
    
    private bool timerIsRunning=false;

    public int overallPumpkinCount = 0;

    GameObject[] players;

    [SerializeField]
    private TextMeshProUGUI scoreTitle;

    [SerializeField]
    private TextMeshProUGUI timeTitle;

    [SerializeField]
    private AudioSource pumpkinSaveSoundEffect;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning){
            
            int currPumpkins=0;
            
            foreach(GameObject gobject in players){
                currPumpkins+=gobject.GetComponent<MinifigController>().pumpkinCount;
            }
            
            if(timeRemaining>0){
                
                timeRemaining-=Time.deltaTime;
                SetTime();
                SetScore((overallPumpkinCount + currPumpkins));

                if((overallPumpkinCount + currPumpkins)>=neededPumpkins)
                {
                    // Load player win scene
                    SceneManager.LoadScene("Results");
                    WinnerStorage.WinnerRole = "Collector team";
                }

            }else{
                
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
            int pumpkinHelper = controller.pumpkinCount;
            controller.pumpkinCount = 0;
            StartCoroutine(SavePumpkinsSound(pumpkinHelper));
            overallPumpkinCount+=pumpkinHelper;
        }
    }


    IEnumerator SavePumpkinsSound(int amount){
        for(int i = 0; i<amount; i++){
            pumpkinSaveSoundEffect.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetScore(int currentScore){
        scoreTitle.SetText($"{currentScore} / {neededPumpkins} Pumpkins");
    }

    void SetTime(){
        double remainingSeconds = Math.Round(timeRemaining);
        timeTitle.SetText($"{remainingSeconds} s");
    }
}
