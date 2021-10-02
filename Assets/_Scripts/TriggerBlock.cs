using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{

    public int weight = 1;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Ice"))
        {
            other.GetComponent<IceBlock>().ReduceValue(weight);
        }
    }

    
}
