using System.Collections.Generic;
using UnityEngine;
using Unity.LEGO.Game;
using Unity.LEGO.Minifig;
using System.Collections;

public class SwampSpace : MonoBehaviour
{
    public AudioSource swampEnterSFX;
    private List<Collider> presentColliders = new List<Collider>();

    void OnTriggerEnter(Collider other){
        if(presentColliders.Count==1){
            swampEnterSFX.Play();
        }
        presentColliders.Add(other);
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
        if(presentColliders.Count==1){
            swampEnterSFX.Stop();
        }
        presentColliders.Remove(other);
    }
}
