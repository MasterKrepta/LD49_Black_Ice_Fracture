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

    AudioSource audio;
    public AudioClip[] cracks;



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
        audio = GetComponent<AudioSource>();
        _remainingValue = MaxValue;
        material = GetComponent<Renderer>().material;
        InitColors();
        
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


    void InitColors()
    {
        if (RemainingValue <= 3)
        {
            material.SetColor("IceColor", WarningColor);
            material.SetColor("FresnelColor", WarningFresnel);
        }

        if (RemainingValue == 1)
        {
            material.SetColor("IceColor", BreakColor);
            material.SetColor("FresnelColor", breakFresnel);
        }
        
    }
    private void SetColor()
    {
        if (RemainingValue <= 4)
        {
            SetWarningColor();
        }

        if (RemainingValue <= 2)
        {
            //InvokeRepeating("PulseColor", 1, 0.5f);
            SetAboutToBreakColor();
        } else
        {
            audio.clip = cracks[0];
            audio.Play();
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
        RemainingValue -= dmg;
    }

    void SetWarningColor()
    {
        audio.clip = cracks[1];
        audio.Play();
        material.SetColor("IceColor", WarningColor);
        material.SetColor("FresnelColor", WarningFresnel);
        
    }

    void SetAboutToBreakColor()
    {
        audio.clip = cracks[2];
        audio.Play();
        material.SetColor("IceColor", BreakColor);
        material.SetColor("FresnelColor", breakFresnel);
        
    }

    void PulseColor()
    {
        //Color.Lerp(material.SetColor("IceColor", WarningColor), material.SetColor("IceColor", BreakColor), 0.5f);
        
    }

}
