using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Killbox : MonoBehaviour
{
    public GameObject Reloading;

    private void Start()
    {
        Reloading.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Reboot");
        }
    }

    IEnumerator Reboot()
    {
        Reloading.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
