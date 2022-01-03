using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.LEGO.Minifig;

public class PlayerInputHandler : MonoBehaviour
{
    public MinifigController player;
    public PlayerConfiguration config;
    private PlayerControls controls;

    private void Awake() {
        controls = new PlayerControls();    
    }

    public void InitializePlayer(PlayerConfiguration pc){
        config = pc;
        if(pc.Input == null)
            Debug.Log("NOT NULL");
        config.Input.onActionTriggered += Input_onActionTriggered;
        player = GameObject.Instantiate(config.PlayerPrefab,transform.position, transform.rotation).GetComponent<MinifigController>();
    }

    private void Input_onActionTriggered(InputAction.CallbackContext obj){
        Debug.Log(obj.action.name);
        Debug.Log(controls.Player.Movement.name);

        if(obj.action.name == controls.Player.Movement.name){
            Move(obj);
        }
    }

    void Start()
    {
        controls = new PlayerControls();    
    }

    public void Move(InputAction.CallbackContext context){
        if(player)
            player.OnMove(context.ReadValue<Vector2>());
    }
}
