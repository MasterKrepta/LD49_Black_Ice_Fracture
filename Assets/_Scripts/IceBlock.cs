using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    [SerializeField]
    private int _remainingValue;
    public Action OnValueChange;
    public Color WarningColor, BreakColor;
    Material material;
    public int MaxValue;


    private void OnEnable()
    {
        OnValueChange += SetColor;
    }

    private void OnDisable()
    {
        OnValueChange -= SetColor;
    }

    void Awake()
    {
        _remainingValue = MaxValue;
        material = GetComponent<Renderer>().material;
        SetColor();
    }

    private void SetColor()
    {
        if (RemainingValue <= 2)
        {
            SetWarningColor();
        }

        if (RemainingValue == 1)
        {
            SetAboutToBreakColor();
        }
    }

    public int RemainingValue
    {
        get { return _remainingValue; }
        set 
        { 
            _remainingValue = value;
            OnValueChange();

            if (RemainingValue <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        //todo play death animations
        Destroy(gameObject);
    }

    
    

    
    public void ReduceValue(int dmg)
    {
        //TODO change color when it gets down to the last 3? or so
        RemainingValue -= dmg;
    }

    void SetWarningColor()
    {
        material.SetColor("IceColor", WarningColor);
    }

    void SetAboutToBreakColor()
    {
        material.SetColor("IceColor", BreakColor);
    }

}
