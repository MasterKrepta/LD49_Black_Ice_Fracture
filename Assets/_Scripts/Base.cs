using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public int itemCount = 0;
    public int WinningTotal = 3;
    public List<Transform> StagingPoints = new List<Transform>();

    public int CurrentLevel;


    private void Awake()
    {
        foreach (Transform child in transform)
        {
            StagingPoints.Add(child);
        }

        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

        
    }

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
        PlayerMovement.canCarry = true;
        TriggerBlock.DecreaseWeight();

        if (itemCount >= WinningTotal )
        {
            SceneManager.LoadScene(++CurrentLevel);
            //TODO LoadNextLevel
        }
    }

}
