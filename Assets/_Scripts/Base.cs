using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int itemCount = 0;
    public int WinningTotal = 3;
    public Transform[] StagingPoints;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            DeliverItem(other.gameObject);
        }
    }


    void DeliverItem(GameObject pickup)
    {
        itemCount++;

        pickup.transform.SetParent(StagingPoints[itemCount - 1]);
        pickup.transform.localPosition = new Vector3(0, -4 ,0);
        
        pickup.tag = "Untagged";

        if (itemCount >= WinningTotal )
        {
            //TODO LoadNextLevel
        }
    }

}
