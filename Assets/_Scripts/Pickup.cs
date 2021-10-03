using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform pickupPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerMovement.canCarry)
        {
            PlayerMovement.canCarry = false;
            transform.position = pickupPoint.position;
            transform.SetParent(pickupPoint.transform);
        }
    }
}
