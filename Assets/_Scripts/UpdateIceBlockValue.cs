using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateIceBlockValue : MonoBehaviour
{

    TMP_Text text;
    IceBlock block;
    PlayerController player;
    private void OnEnable()
    {
        block = transform.parent.parent.GetComponent<IceBlock>();
        block.OnValueChange += ChangeValue;
        text = GetComponent<TMP_Text>();
        player = FindObjectOfType<PlayerController>();
    }


    private void Start()
    {
        text.text = block.RemainingValue.ToString();
    }
    private void OnDisable()
    {
        block.OnValueChange -= ChangeValue;
    }

    void ChangeValue()
    {
        
        text.text = block.RemainingValue.ToString();
        
    }
}
