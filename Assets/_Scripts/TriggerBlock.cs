using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{

    public static int weight = 1;

    AudioSource audio;
    public AudioClip[] cracks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Ice"))
        {
            other.GetComponent<IceBlock>().ReduceValue(weight);
        }
    }


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    public static void IncreaseWeight()
    {
        weight++;
    }

    public static void DecreaseWeight()
    {
        weight--;
    }
}
