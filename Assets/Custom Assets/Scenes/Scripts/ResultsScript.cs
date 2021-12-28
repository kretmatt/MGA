using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScript : MonoBehaviour
{
   // Switch to player configuration
    public void SwitchToPlayerConfiguration(){
        SceneManager.LoadScene("Happy Halloween");
    }

    // Switch to main menu
    public void SwitchToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
