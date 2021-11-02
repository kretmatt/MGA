using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoleScript : MonoBehaviour
{
    // First character is hunter
    [SerializeField]
    public List<GameObject> characters = new List<GameObject>();
    PlayerInputManager manager;
    int index=0;

    // Random variable


    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = characters[index]; 
    }

    public void SwitchToCollectors(PlayerInput input)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        manager.playerPrefab = characters[Random.Range(1, characters.Count)]; 
    }
}
