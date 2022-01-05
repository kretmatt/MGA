using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsTitle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;

    void Start() {
        title.SetText($"{WinnerStorage.WinnerRole} wins!");   
    }
}
