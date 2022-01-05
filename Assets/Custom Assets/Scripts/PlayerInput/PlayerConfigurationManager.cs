using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigurations;
    [SerializeField]
    private int MaxPlayers = 2;
    [SerializeField]
    private GameObject hunterPrefab;

    public static PlayerConfigurationManager Instance { get; private set; }
    
    private void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigurations = new List<PlayerConfiguration>();
        }
        playerConfigurations.Clear();
    }

    public void SetPlayerPrefab(int index, GameObject playerPrefab){
        playerConfigurations[index].PlayerPrefab = playerPrefab;
    }

    public void ReadyPlayer(int index){
        playerConfigurations[index].Ready = true;
        if(playerConfigurations.Count == MaxPlayers && playerConfigurations.All(p => p.Ready == true)){
            if(!playerConfigurations.Any(p=>p.PlayerPrefab.CompareTag("Hunter"))){
                var randomHunterPlayer = Random.Range(0, playerConfigurations.Count());
                playerConfigurations[randomHunterPlayer].PlayerPrefab = hunterPrefab; 
            }
            SceneManager.LoadScene("Happy Halloween");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi){
        pi.transform.SetParent(transform);
        if(!playerConfigurations.Any(p=>p.PlayerIndex == pi.playerIndex)){
            playerConfigurations.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs(){
        return playerConfigurations;
    }

    public void ClearConfigs(){
        playerConfigurations.Clear();
    }
}
