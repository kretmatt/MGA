using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerNameTag : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameTitle;

    public void SetName(string newName){
        nameTitle.SetText(newName);
        // Set Color
    }
}
