using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 25;
    public float rotateSpeed = 1;
    public float jumpHeight = 250f;
    private Rigidbody rb;
    public int grounded = 0;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-transform.up * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * rotateSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded < 1)
        {
            grounded += 1;
            rb.AddForce(transform.up * jumpHeight);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Playfield")
        {
            grounded = 0;
        }
    }
}
