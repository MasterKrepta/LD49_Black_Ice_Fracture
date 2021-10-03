using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public int itemCount = 0;
    public int WinningTotal = 3;
    public List<Transform> StagingPoints = new List<Transform>();
    public Transform droppointParent;

    public int CurrentLevel;


    private void Awake()
    {
        foreach (Transform child in droppointParent)
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
        GetComponent<AudioSource>().Play();
        itemCount++;
        pickup.transform.eulerAngles = Vector3.zero;
        pickup.transform.SetParent(StagingPoints[itemCount - 1]);
        pickup.transform.localPosition = new Vector3(-0.0006f, 0 ,0.0238f);
        
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
