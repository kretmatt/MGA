using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;

    [SerializeField]
    private AudioSource deathSoundEffect;

    public void Respawn(Transform playerTransform){
        playerTransform.position = respawnPoint.position;
        deathSoundEffect.Play();
    }
}
