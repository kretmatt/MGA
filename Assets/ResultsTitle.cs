using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsTitle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private AudioSource collectorJingle;

    [SerializeField]
    private AudioSource hunterJingle;


    void Start() {
        if(WinnerStorage.WinnerRole == "Hunter")
            hunterJingle.Play();
        else
            collectorJingle.Play();
        title.SetText($"{WinnerStorage.WinnerRole} wins!");   
    }
}
