using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Game;
using Unity.LEGO.Minifig;
using System.Collections;

public class SwampSpace : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            var controller = other.GetComponent<MinifigController>();
            controller.slowedDown=true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            var controller = other.GetComponent<MinifigController>();
            controller.slowedDown=false;
        }
    }
}
