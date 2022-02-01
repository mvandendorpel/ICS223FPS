using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;
    private float speed = 15f;
    private float force = 1000f;
    private float horizInput, vertInput;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizInput, 0, vertInput) * force * Time.fixedDeltaTime;
        //rbody.AddForce(movement);
        rbody.velocity = movement;
    }
}
