using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsScript : MonoBehaviour
{
   // Switch to credits
    public void SwitchToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
