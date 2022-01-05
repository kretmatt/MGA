using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.LEGO.Minifig;

public class PlayerInputHandler : MonoBehaviour
{
    public MinifigController player;
    public PlayerConfiguration config;

    public void InitializePlayer(PlayerConfiguration pc){
        config = pc;
        player = GameObject.Instantiate(config.PlayerPrefab,transform.position, transform.rotation).GetComponent<MinifigController>();
    }

    public void Move(InputAction.CallbackContext context){
        if(player){
            player.OnMove(context.ReadValue<Vector2>());
        }
    }
}
