using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScript : MonoBehaviour
{
    private void Start() {
        // Destroy player configuration manager
        Destroy (GameObject.Find("PlayerConfigurationManager"));
    }

    // Switch to player configuration
    public void SwitchToPlayerConfiguration(){
        SceneManager.LoadScene("PlayerConfiguration");
    }

    // Switch to main menu
    public void SwitchToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
