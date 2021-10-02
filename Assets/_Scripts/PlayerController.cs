using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float moveHorizontal;
    float moveVertical;
    Vector3 movement;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
