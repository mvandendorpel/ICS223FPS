using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float speed = 9.0f;
    private float gravity = -9.8f;
    private CharacterController charController;
    private float pushForce = 5.0f;
    //Vector3(-11.2,0,8.5) / Vector3(-9.11999989,0,9.84039974)
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(deltaX, 0.0f,  deltaY);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement.y = gravity;
        movement *= speed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}
