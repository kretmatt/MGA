using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.LEGO.Minifig;

public class PlayerInputHandler : MonoBehaviour
{
    public MinifigController player;
    public GameObject playerPrefab;

    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();

    private static bool hunterSpawned=false;
    // Start is called before the first frame updatea
    void Start()
    {
        if(hunterSpawned==false){
            GameObject hunter = prefabs[0];
            hunter.tag = "Hunter";
            player = GameObject.Instantiate(hunter,transform.position, transform.rotation).GetComponent<MinifigController>();
            hunterSpawned=true;
        }
        else
            player = GameObject.Instantiate(prefabs[Random.Range(1, prefabs.Count)],transform.position, transform.rotation).GetComponent<MinifigController>();
    }

    public void Move(InputAction.CallbackContext context){
        if(player)
            player.OnMove(context.ReadValue<Vector2>());
    }
}
