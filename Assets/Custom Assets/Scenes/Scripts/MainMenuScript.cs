using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    // Switch to player configuration
    public void SwitchToPlayerConfiguration(){
        SceneManager.LoadScene("PlayerConfiguration");
    }

    // Close the game
    public void QuitTheGame(){
        Application.Quit();
    }

    // Switch to credits
    public void SwitchToCredits(){
        SceneManager.LoadScene("Credits");
    }
}
