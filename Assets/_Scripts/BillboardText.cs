using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        //transform.rotation = Camera.main.transform.rotation;
    }
}
