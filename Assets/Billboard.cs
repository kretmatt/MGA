using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(Camera.main.transform)
            mainCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(mainCameraTransform){
            transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
        }
    }
}
