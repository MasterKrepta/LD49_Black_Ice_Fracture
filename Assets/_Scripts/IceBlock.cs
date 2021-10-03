using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    [SerializeField]
    private int _remainingValue;
    public Action OnValueChange;
    public Color WarningColor, BreakColor, WarningFresnel, breakFresnel;
    Material material;
    public int MaxValue;

    public GameObject numberLabel;

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

    private void Start()
    {
        CreateLabel();
    }
    private void CreateLabel()
    {
        var lbl = Instantiate(numberLabel, transform.position, Quaternion.identity, transform);
        lbl.GetComponent<RectTransform>().position = new Vector3(transform.position.x, 0.25f , transform.position.z);
    }

    private void SetColor()
    {
        if (RemainingValue <= 3)
        {
            SetWarningColor();
        }

        if (RemainingValue == 1)
        {
            //InvokeRepeating("PulseColor", 1, 0.5f);
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
        material.SetColor("FresnelColor", WarningFresnel);
    }

    void SetAboutToBreakColor()
    {
        material.SetColor("IceColor", BreakColor);
        material.SetColor("FresnelColor", breakFresnel);
    }

    void PulseColor()
    {
        //Color.Lerp(material.SetColor("IceColor", WarningColor), material.SetColor("IceColor", BreakColor), 0.5f);
        
    }

}
