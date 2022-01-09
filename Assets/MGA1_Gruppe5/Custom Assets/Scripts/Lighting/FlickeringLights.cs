using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    private bool flickering = false;
    private float timeDelay;

    public float minFlicker=0.5f;
    public float maxFlicker=2.5f;

    void Update()
    {
        if(flickering == false)
            StartCoroutine(Flicker());
    }

    IEnumerator Flicker(){
        flickering = true;
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.5f, 2.5f);        
        yield return new WaitForSeconds(timeDelay);
        flickering = false;
    }
}
