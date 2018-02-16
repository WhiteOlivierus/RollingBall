using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float moveSpeed = 10;
    public float rotateSpeed = 1;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
        }else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed);
        }else if (Input.GetKey(KeyCode.A)){
            rb.AddTorque(-transform.up * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D)){
            rb.AddTorque(transform.up * rotateSpeed);
        }
    }
}
